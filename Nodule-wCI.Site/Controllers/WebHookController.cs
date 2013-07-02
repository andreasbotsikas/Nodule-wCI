using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Miscellaneous.Attributes.Controller;
using Nodule_wCI.DB;
using Nodule_wCI.Site.Code;

namespace Nodule_wCI.Site.Controllers
{
    public class WebHookController : Controller
    {
        // Logger helper
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The end point to place in your github WebHook URLs
        /// </summary>
        /// <param name="payload">A Json object as decribed in https://help.github.com/articles/post-receive-hooks</param>
        /// <returns>A json object with the result of the registration</returns>
        [HttpPost, AllowCrossSiteJson, FilterIP(ConfigurationKeyAllowedMaskLevelIPs="GithubPublicIps")]
        public JsonResult EndPoint(string payload)
        {
            // Warning: FilterIP is not that secure but atleast it will discourage the script kids from messing arround
            if (string.IsNullOrEmpty(payload))
            {
                Logger.Warn("Recieved payload is empty");
                return Json(new { result = false });
            }
            try
            {
                long postId = 0;
                using (var db = new NoduleDbEntities())
                {
                    var post = db.ParseWebHookPost(payload);
                    db.WebHookPosts.Add(post);
                    db.SaveChanges();
                    postId = post.Id;
                }
                if (postId > 0)
                {
                    try
                    {
                        // Fire the request and forget about it
                        var c = new NoduleWorker.ProcessorClient();
                        c.StartProcessRequest(postId);
                    }
                    catch (Exception initiateProcessingException)
                    {
                        Logger.ErrorException(string.Format("Failed to trigger processing of post with id {0}", postId),initiateProcessingException);
                    }
                }
                return Json(new { result = true });
            }
            catch (Exception ex)
            {  
                Logger.LogException(NLog.LogLevel.Error,string.Format("Error parsing endpoint payload: {0}", payload),ex);
                return Json(new { result = false });
            }
        }

    }
}
