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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(30)]
        [Key]
        public string SlackUserID { get; set; }

        public string Name { get; set; }

        public string SlackTeamID { get; set; }

        [Required]
        public virtual SlackTeam SlackTeam { get; set; }
        public virtual ICollection<SlackUserRepositoryAccess> RepositoryAccesses { get; set; }
        public virtual ICollection<Subscriber> Subscriptions { get; set; }
    }
}
