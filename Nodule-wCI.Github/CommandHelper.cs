using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nodule_wCI.Github
{
    public class CommandHelper
    {

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.github.com");

            client.DefaultRequestHeaders.Add("Authorization", string.Format("token {0}",ConfigurationManager.AppSettings["tokenKey"]));
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.116 Safari/537.36");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.8,el;q=0.6");
            return client;
        }

        public enum CommitStatus
        {
            pending = 1, 
            success = 2, 
            error = 3, 
            failure =4
        }

        public void PushCommitStatus(string owner, string repositoryName, string commitSHA, CommitStatus status, string message,
                                     string url)
        {
            var client = GetClient();
            client.Post(string.Format("/repos/{0}/{1}/statuses/{2}", owner, repositoryName, commitSHA), new
                {
                    state = status.ToString(),
                    target_url =url,
                    description = message
                });
        }

        public void AddPullRequestComment(string owner, string repositoryName, int pullRequestNo, string message)
        {
            var client = GetClient();
            client.Post(string.Format("/repos/{0}/{1}/issues/{2}/comments", owner, repositoryName, pullRequestNo), new
            {
                body = message
            });
        }

        /// <summary>
        /// TODO: add more fields
        /// </summary>
        public class Comment
        {
            public long Id { get; set; }
            public string Messsage { get; set; }
            public string Username { get; set; }
            public string Created { get; set; }
        }

        public List<Comment> GetCommitComments(string owner, string repositoryName, string commitSha)
        {
            var output = new List<Comment>();
            var client = GetClient();
            var comments = client.Get(string.Format("/repos/{0}/{1}/commits/{2}/comments", owner, repositoryName, commitSha));
            foreach (dynamic comment in comments)
            {
                output.Add(new Comment()
                {
                    Id = comment.id,
                    Messsage = comment.body,
                    Username = comment.user.login,
                    Created = comment.created_at
                });
            }
            return output;
        }

        public void UpdateCommitComment(string owner, string repositoryName, string commitSha,long id, string message)
        {
            var client = GetClient();
            client.Patch(string.Format("/repos/{0}/{1}/commits/{2}/comments/{3}", owner, repositoryName, commitSha,id), new
            {
                body = message
            });
        }

        public void AddCommitComment(string owner, string repositoryName, string commitSha, string message)
        {
            var client = GetClient();
            client.Post(string.Format("/repos/{0}/{1}/commits/{2}/comments", owner, repositoryName, commitSha), new
            {
                body = message
            });
        }

        public void AttachWebHook(string owner, string repositoryName, string webhookUrl)
        {
            var client = GetClient();
            dynamic hooks = client.Get(string.Format("/repos/{0}/{1}/hooks", owner, repositoryName));
            int hookId = -1;
            dynamic foundHook = null;
            foreach (dynamic hook in hooks)
            {
                if (hook.config.url == webhookUrl)
                {
                    hookId = hook.id;
                    foundHook = hook;
                    break;
                }
            }
            // If we couldn't find the hook
            if (hookId == -1)
            {
                // Add one
                client.Post(string.Format("/repos/{0}/{1}/hooks", owner, repositoryName), new
                    {
                        name = "web",
                        active = true,
                        events = new string[] { "push", "pull_request" },
                        config = new
                        {
                            url = webhookUrl,
                            content_type = "json"
                        }
                    });
            }
            else
            {
                // we do have a hook check if pull_request event is there
                bool foundEvent = false;
                foreach (string s in foundHook.events)
                {
                    if (s == "pull_request")
                    {
                        foundEvent = true;
                        break;
                    }
                }
                if (!foundEvent)
                {
                    // Add the pull_request event
                    client.Patch(string.Format("/repos/{0}/{1}/hooks/{2}", owner, repositoryName, hookId), new
                            {
                                active = true,
                                add_events = new string[] { "pull_request" }
                            });
                }
            }
        }

    }
}
