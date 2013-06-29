using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Nodule_wCI.DB
{
    public partial class NoduleDbEntities
    {
        /// <summary>
        /// Parses the github payload and addes it to the db. Throws exceptions if it fails to do so.
        /// </summary>
        /// <param name="payload">The payload as described in https://help.github.com/articles/post-receive-hooks</param>
        public WebHookPosts ParseWebHookPost(string payload)
        {
            var newPost = new WebHookPosts()
                {
                    Date = DateTime.Now,
                    PostData = payload,
                    StatusId = (int) DB.PostStatuses.AvailableStatuses.JustRecieved
                };

            // Make sure you disable "Enable the visual studio hosting process" while debugging
            var dynamicObject = Json.Decode(payload);
            newPost.PullRequestReference = dynamicObject.@ref;
            newPost.RepoUrl = dynamicObject.repository.url;
            int order = 0; //The first one is the oldest
            foreach (dynamic commit in dynamicObject.commits)
            {
                string commitId = commit.id;
                if (this.Commits.Any(i => i.Id == commitId))
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
                    var newCommit = new DB.Commits
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

    }
}
