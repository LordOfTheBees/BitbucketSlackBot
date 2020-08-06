using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Data
{
    public enum RepositoryAccess
    {
        Block,
        View,
        Admin
    }
    public class SlackUserRepositoryAccess
    {
        public RepositoryAccess RepositoryAccess { get; set; }

        public string SlackUserID { get; set; }
        public string SlackTeamID { get; set; }
        public int BitbucketRepositoryID { get; set; }

        [Required]
        public virtual SlackUser SlackUser { get; set; }
        [Required]
        public virtual BitbucketRepository BitbucketRepository { get; set; }
    }
}
