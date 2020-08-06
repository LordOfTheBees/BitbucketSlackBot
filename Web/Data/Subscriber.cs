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
        public int BitbucketRepositoryID { get; set; }


        //[ForeignKey("SlackUserID")]
        [Required]
        public virtual SlackUser SlackUser { get; set; }
        //[ForeignKey("BitbucketRepositoryID")]
        [Required]
        public virtual BitbucketRepository BitbucketRepository { get; set; }
    }
}
