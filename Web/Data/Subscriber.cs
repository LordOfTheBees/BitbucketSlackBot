using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Data
{
    public class Subscriber
    {
        public bool OnRepositoryCreated { get; set; }


        public string SlackUserID { get; set; }
        public string SlackTeamID { get; set; }
        public Guid BitbucketRepositoryID { get; set; }
        public string BitbucketSlackTeamID { get; set; }


        [Required]
        public virtual SlackUser SlackUser { get; set; }
        [Required]
        public virtual BitbucketRepository BitbucketRepository { get; set; }
    }
}
