using System;
using Nodule_wCI;
using Nodule_wCI.DB;


namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            ////// Make sure you disable "Enable the visual studio hosting process" while debugging
            //using (var db = new NoduleDbEntities())
            //{
            //    var post = db.ParseWebHookPost(System.IO.File.ReadAllText("testPR.js"));
            //    db.WebHookPosts.Add(post);
            //    db.SaveChanges();


            //}
            //var p = new Nodule_wCI.Worker.Processor();
            //p.ProcessNewRequests();

            //var client = new Nodule_wCI.Github.CommandHelper();
            //client.PushCommitStatus("webinos", "webinos-utilities", "9e6371b1a77bb4a82677570a5439f7b7f911a5b3", CommandHelper.CommitStatus.success, "Travis said ok.", "http://webinoswintest.epu.ntua.gr");

            //var client = new Nodule_wCI.Github.CommandHelper();
            //client.AttachWebHook("webinos", "webinos-policy", "http://webinoswintest.epu.ntua.gr/WebHook/EndPoint");

            Console.WriteLine("Tests done. Press key to exit");
            Console.ReadKey();
        }
    }
}
