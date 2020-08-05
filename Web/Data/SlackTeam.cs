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
        [Key]
        public int ID { get; set; }

        public string TeamID { get; set; }


        public ICollection<BitbucketRepository> Repositories { get; set; }
        public ICollection<SlackUser> Users { get; set; }
    }
}
