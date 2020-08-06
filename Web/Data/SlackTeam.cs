using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Data
{
    public class SlackTeam
    {
        public int SlackTeamID { get; set; }

        public string TeamID { get; set; }


        public virtual ICollection<BitbucketRepository> Repositories { get; set; }
        public virtual ICollection<SlackUser> Users { get; set; }
    }
}
