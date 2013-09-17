using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData.Query;
using Nodule_wCI.DB;
using System.Web.Http.OData;

namespace Nodule_wCI.Site.Api
{
    public class ListOfRequestsController : ApiController
    {
        private NoduleDbEntities db = new NoduleDbEntities();

        // GET api/WebHookPosts
        public PageResult<ListOfRequests> GetWebHookPosts(ODataQueryOptions<ListOfRequests> options)
        {
            var query = db.ListOfRequests.AsQueryable();
            var data = options.ApplyTo(query) as IEnumerable<ListOfRequests>;

            return new PageResult<ListOfRequests>(
                    data,
                    Request.GetNextPageLink(),
                    Request.GetInlineCount()
                );
        }

       
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}