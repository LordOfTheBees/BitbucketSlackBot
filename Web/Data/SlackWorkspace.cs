using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Data
{
    public class SlackWorkspace
    {
        public int ID { get; set; }

        public string WorkspaceName { get; set; }

        public string WorkspaceUuid { get; set; }


        public ICollection<BitbucketRepository> Repositories { get; set; }
        public ICollection<SlackUserWorkspaceSettings> Users { get; set; }
    }
}
