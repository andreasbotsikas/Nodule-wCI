using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodule_wCI.DB
{
    public partial class WebHookPosts
    {
        public string GetPullRequestNpmUrl()
        {
            // Note that this code assumes that the address is always an https one,
            // funcy bugs may come out of this.
            return string.Format("git://{0}.git#{1}",this.RepoUrl.Substring("https://".Length),this.PullRequestReference);
        }
    }
}
