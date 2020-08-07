using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Data
{
    public class SlackTeam
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(30)]
        [Key]
        public string SlackTeamID { get; set; }


        public virtual ICollection<BitbucketRepository> Repositories { get; set; }
        public virtual ICollection<SlackUser> Users { get; set; }
    }
}
