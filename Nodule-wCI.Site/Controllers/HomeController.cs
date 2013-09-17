using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nodule_wCI.DB;
using Nodule_wCI.Site.Code;

namespace Nodule_wCI.Site.Controllers
{
    public class HomeController : Controller
    {

        private NoduleDbEntities db = new NoduleDbEntities();
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuildLog(long? id)
        {
            if (!id.HasValue) id = -1;
            return View(db.WebHookPosts.Where(i => i.Id == id).SingleOrDefault());
        }

        private const string PngMimeType = "image/png";

        [NoCache]
        public FileResult BuildStatus(long id, string rnd = "")
        {
            var status = (int)db.WebHookPosts.Where(i => i.Id == id).Select(i => i.StatusId).SingleOrDefault();
            switch (status)
            {
                case (int) Nodule_wCI.Enums.PostStatus.Failed:
                    return new FilePathResult(Server.MapPath("~/Content/StatusImages/Error.png"), PngMimeType);
                case (int)Nodule_wCI.Enums.PostStatus.JustRecieved:
                    return new FilePathResult(Server.MapPath("~/Content/StatusImages/Idle.png"), PngMimeType);
                case (int)Nodule_wCI.Enums.PostStatus.Processing:
                    return new FilePathResult(Server.MapPath("~/Content/StatusImages/Processing.png"), PngMimeType);
                case (int)Nodule_wCI.Enums.PostStatus.Success:
                    return new FilePathResult(Server.MapPath("~/Content/StatusImages/Success.png"), PngMimeType);
                default: // 0 in case the pr is not found
                    return new FilePathResult(Server.MapPath("~/Content/StatusImages/Warning.png"), PngMimeType);
            }
        }

        public ActionResult RestartBuild(long? id)
        {
            if (!id.HasValue) id = -1;
            // Fire the request and forget about it
            var c = new NoduleWorker.ProcessorClient();
            c.StartProcessRequest(id.Value);
            return View(db.WebHookPosts.Where(i => i.Id == id.Value).SingleOrDefault());
        }
    }
}
