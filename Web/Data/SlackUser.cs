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
        public int ID { get; set; }

        public string Name { get; set; }


        [ForeignKey("SlackTeam")]
        public int TeamID { get; set; }


        public SlackTeam Team { get; set; }
        public ICollection<SlackUserRepositoryAccess> RepositoryAccesses { get; set; }
        public ICollection<Subscriber> AllSubscriptions { get; set; }
    }
}
