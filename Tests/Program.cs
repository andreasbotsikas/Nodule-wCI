using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Make sure you disable "Enable the visual studio hosting process" while debugging
            //using (var db = new NoduleDbEntities())
            //{
            //    var c = new Worker.ProcessorClient();
            //    var i = c.ProcessNewRequests();
            //    Console.WriteLine("Result {0}",i);
            //    //var post = db.ParseWebHookPost(System.IO.File.ReadAllText("GitHubPostSample.json"));
            //    //db.WebHookPosts.Add(post);
            //    //db.SaveChanges();

           
            //}
            var p = new Nodule_wCI.Worker.Processor();
            p.ProcessNewRequests();
            Console.WriteLine("Tests done. Press key to exit");
            Console.ReadKey();
        }
    }
}
