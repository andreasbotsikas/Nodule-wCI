using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nodule_wCI.DB;

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
            // Show something
            return View(db.WebHookPosts);
        }

        public ActionResult BuildLog(long? prId)
        {
            if (!prId.HasValue) prId = -1;
            return View(db.WebHookPosts.SingleOrDefault(i => i.Id == prId));
        }
    }
}
