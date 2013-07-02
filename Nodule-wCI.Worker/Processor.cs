using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Nodule_wCI.DB;
using Nodule_wCI.Worker.Helpers;

namespace Nodule_wCI.Worker
{
    // Allow multiple calls but initiate a new context for each call
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
    public class Processor : IProcessor
    {

        static Processor()
        {
            // Update the location of the database file based on app setting
            AppDomain.CurrentDomain.SetData("DataDirectory", ConfigurationManager.AppSettings["DataFileLocation"]);
        }

        // Logger helper
        private static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();

        public bool ProcessNewRequests()
        {
            var output = true;
            try
            {
                long[] newRequests;
                using (var db = new NoduleDbEntities())
                {
                    const int unprocessedStatus = (int)DB.PostStatuses.AvailableStatuses.JustRecieved;
                    newRequests =
                        db.WebHookPosts.Where(i => i.StatusId == unprocessedStatus).Select(i => i.Id).ToArray();
                }
                // Process all the new requests
                foreach (var request in newRequests)
                {
                    output = ProcessRequest(request) && output; 
                }
                // We don't stop processing the rest of the requests if one fails
                return output;
            }
            catch (Exception ex)
            {
                Log.ErrorException("Failed to process new request", ex);
                return false;
            }
        }

        public bool ProcessRequest(long requestId)
        {
            try
            {
                using (var db = new NoduleDbEntities())
                {
                    var request = db.WebHookPosts.SingleOrDefault(i => i.Id == requestId);
                    if (request == null)
                    {
                        Log.Warn(string.Format("Could not locate request with id {0}", requestId));
                        return false;
                    }
                    // Mark as processing
                    request.StatusId = (byte)PostStatuses.AvailableStatuses.Processing;
                    db.SaveChanges();
                    // Create temp path
                    var workingDir = PathHelpers.GetTempFolder();
                    try
                    {
                        var npm = new NpmInstaller();
                        var output = npm.ProcessEntrySync(workingDir,request.GetPullRequestNpmUrl());
                        PostStatuses.AvailableStatuses newStatus = output
                                                                       ? PostStatuses.AvailableStatuses.Success
                                                                       : PostStatuses.AvailableStatuses.Failed;
                        request.StatusId = (byte) newStatus;
                        request.Result = npm.Output;
                    }
                    catch (Exception npmException)
                    {

                        Log.ErrorException(string.Format("Failed to do npm install on request with id {0}", requestId),
                                           npmException);
                        // Reset status to process it later
                        request.StatusId = (int) PostStatuses.AvailableStatuses.JustRecieved;
                        db.SaveChanges();
                        return false;
                    }
                    if (request.StatusId == (int) PostStatuses.AvailableStatuses.Success)
                    {
                        // If it was build ok do a dependency walk
                        // TODO: Hookup dependency walk
                    }
                    // Delete temp path
                    PathHelpers.DeleteRecursively(workingDir);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.ErrorException(string.Format("Failed to process request with id {0}", requestId), ex);
                return false;
            }
        }

        #region Async wcf calls
        public IAsyncResult BeginProcessRequest(long requestId, AsyncCallback callback, object state)
        {
            var result = Task<bool>.Factory.StartNew((taskState) => ProcessRequest(requestId), state);
            // Continue with callback if defined
            if (callback != null)
            {
                result.ContinueWith((t) => callback(t));
            }
            return result;
        }

        public bool EndProcessRequest(IAsyncResult r)
        {
            return ((Task<bool>) r).Result;
        }

        public IAsyncResult BeginProcessNewRequests(AsyncCallback callback, object state)
        {
            var result = Task<bool>.Factory.StartNew((taskState) => ProcessNewRequests(), state);
            // Continue with callback if defined
            if (callback != null)
            {
                result.ContinueWith((t) => callback(t));
            }
            return result;
        }

        public bool EndProcessNewRequests(IAsyncResult r)
        {
            return ((Task<bool>)r).Result;
        }
        #endregion
        #region Fire and forger implementation
        public void StartProcessRequest(long requestId)
        {
            ProcessRequest(requestId);
        }

        public void StartProcessNewRequests()
        {
            ProcessNewRequests();
        }
        #endregion
    
    }
}
