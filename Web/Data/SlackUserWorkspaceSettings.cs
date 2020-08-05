using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Data
{
    public class SlackUserWorkspaceSettings
    {
        public int SlackUserID { get; set; }
        public int SlackWorkspaceID { get; set; }

        public SlackUser User { get; set; }
        public SlackWorkspace Workspace { get; set; }
    }
}
