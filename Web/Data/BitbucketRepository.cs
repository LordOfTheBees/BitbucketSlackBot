using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Data
{
    public enum CommonRepositoryAccess
    {
        AllView, AllBlock, AllAdmin, AccessSettingsDefView, AccessSettingsDefBlock, AccessSettingsDefAdmin
    }

    public class BitbucketRepository
    {
        public int ID { get; set; }


        public string Workspace { get; set; }
        public string Repository { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public CommonRepositoryAccess CommonAccess { get; set; }


        [ForeignKey("SlackWorkspace")]
        public int SlackWorkspaceOwnerID { get; set; }


        [Required]
        public SlackWorkspace SlackWorkspaceOwner { get; set; }
        public ICollection<SlackUserRepositoryAccess> RepositoryAccesses { get; set; }
        public ICollection<Subscriber> AllSubscribers { get; set; }
    }
}
