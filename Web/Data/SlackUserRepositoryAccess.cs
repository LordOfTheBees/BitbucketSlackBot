﻿using Microsoft.AspNetCore.SignalR;
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


        public int SlackUserID { get; set; }
        public int BitbucketRepositoryID { get; set; }


        public SlackUser SlackUser { get; set; }
        public BitbucketRepository Repository { get; set; }
    }
}