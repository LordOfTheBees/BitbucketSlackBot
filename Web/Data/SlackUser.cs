using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Data
{
    public class SlackUser
    {
        [Key]
        public int SlackUserID { get; set; }

        public string UserIdentifier { get; set; }
        public string Name { get; set; }

        public int? SlackTeamID { get; set; }

        [Required]
        public virtual SlackTeam SlackTeam { get; set; }
        public virtual ICollection<SlackUserRepositoryAccess> RepositoryAccesses { get; set; }
        public virtual ICollection<Subscriber> Subscriptions { get; set; }
    }
}
