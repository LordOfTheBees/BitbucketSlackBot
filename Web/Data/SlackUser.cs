using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Data
{
    public class SlackUser
    {
        public int ID { get; set; }

        public string User { get; set; }

        public string UserUuid { get; set; }


        public ICollection<SlackUserWorkspaceSettings> Workspaces { get; set; }
        public ICollection<SlackUserRepositoryAccess> RepositoryAccesses { get; set; }
        public ICollection<Subscriber> AllSubscriptions { get; set; }
    }
}
