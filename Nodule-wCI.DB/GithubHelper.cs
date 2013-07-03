using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Helpers;
using Nodule_wCI.Enums;
#if DB_VIA_PROXY
using Nodule_wCI.Worker.NoduleDb;
#else
using Nodule_wCI.DB;
#endif
namespace Nodule_wCI
{
    // This file is also linked in the worker to provide the same functionallity there too
    public static class GithubHelper
    {

        //Repo urls are  in the following format 
        //git@github.com:webinos/webinos-utilities.git
        //https://github.com/webinos/webinos-utilities.git
        //https://github.com/webinos/webinos-utilities
        public static Regex  RepositoryUrlParser = new Regex(
            "(?:https://|git@)github.com(?:/|:)(?<Organization>[^/]+)/(?<Repository>[^\\.]*)(?:\\.git)?",
            RegexOptions.CultureInvariant | RegexOptions.Compiled | RegexOptions.IgnoreCase
        );

        /// <summary>
        /// Parses the github payload and addes it to the db. Throws exceptions if it fails to do so.
        /// </summary>
        /// <param name="db">The db service to look up commits</param>
        /// <param name="payload">The payload as described in https://help.github.com/articles/post-receive-hooks</param>
        public static WebHookPosts ParseWebHookPost(this NoduleDbEntities db, string payload)
        {
            var newPost = new WebHookPosts()
            {
                Date = DateTime.Now,
                PostData = payload,
                StatusId = (int)PostStatus.JustRecieved
            };

            // Make sure you disable "Enable the visual studio hosting process" while debugging
            var dynamicObject = Json.Decode(payload);
            newPost.PullRequestReference = dynamicObject.@ref;
            newPost.RepoUrl = dynamicObject.repository.url;

            // Parse the organization in order to show them easier
            if (RepositoryUrlParser.IsMatch(newPost.RepoUrl))
            {
                newPost.Organization = RepositoryUrlParser.Match(newPost.RepoUrl).Groups["Organization"].Value;
            }

            int order = 0; //The first one is the oldest
            foreach (dynamic commit in dynamicObject.commits)
            {
                string commitId = commit.id;
                if (db.Commits.Any(i => i.Id == commitId))
                {
                    // No need to add the commit in the db
                    newPost.WebHookPostCommits.Add(new WebHookPostCommits()
                    {
                        CommitId = commitId,
                        Order = order
                    });
                }
                else
                {
                    //Create the new commit and associate it with the post
                    var newCommit = new Commits
                    {
                        Id = commitId,
                        Date = DateTime.Parse(commit.timestamp),
                        Message = commit.message,
                        Url = commit.url,
                        AddedNo = commit.added != null ? commit.added.Length : 0,
                        DeletedNo = commit.removed != null ? commit.removed.Length : 0,
                        ModifiedNo = commit.modified != null ? commit.modified.Length : 0
                    };
                    if (commit.committer != null)
                    {
                        newCommit.Username = commit.committer.username;
                        newCommit.Name = commit.committer.name;
                        newCommit.Email = commit.committer.email;
                    }
                    newPost.WebHookPostCommits.Add(new WebHookPostCommits()
                    {
                        Commits = newCommit,
                        Order = order
                    });
                }
                order++;
            }

            return newPost;
        }

        public static string GetPullRequestNpmUrl(this WebHookPosts post)
        {
            // Note that this code assumes that the address is always an https one,
            // funcy bugs may come out of this.
            return string.Format("git://{0}.git#{1}", post.RepoUrl.Substring("https://".Length), post.PullRequestReference);
        }
    }
}
