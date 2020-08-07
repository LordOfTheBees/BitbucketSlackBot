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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Guid BitbucketRepositoryUUID { get; set; }


        public string Workspace { get; set; }
        public string Repository { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public CommonRepositoryAccess CommonAccess { get; set; }


        public string SlackTeamID { get; set; }


        [Required]
        public virtual SlackTeam SlackTeam { get; set; }
        public virtual ICollection<SlackUserRepositoryAccess> RepositoryAccesses { get; set; }
        public virtual ICollection<Subscriber> Subscribers { get; set; }
    }
}
