using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bitbucket.API.Data
{
    [DebuggerDisplay("{Id} | {Title}")]
    public partial class PullRequestInfo
    {
        /// <summary>
        /// HTML information for correct displaying data (title and description) of pull request 
        /// </summary>
        [JsonProperty("rendered")]
        public Rendered Rendered { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Links for interactive with pull requests
        /// </summary>
        [JsonProperty("links")]
        public Dictionary<string, Link> Links { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("close_source_branch")]
        public bool CloseSourceBranch { get; set; }

        [JsonProperty("reviewers")]
        public UserInfo[] Reviewers { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("destination")]
        public Destination Destination { get; set; }

        [JsonProperty("created_on")]
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// HTML information for correct displaying description of pull request 
        /// </summary>
        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        [JsonProperty("source")]
        public Destination Source { get; set; }

        [JsonProperty("comment_count")]
        public long CommentCount { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("task_count")]
        public long TaskCount { get; set; }

        [JsonProperty("participants")]
        public Participant[] Participants { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("updated_on")]
        public DateTimeOffset UpdatedOn { get; set; }

        [JsonProperty("author")]
        public UserInfo Author { get; set; }

        [JsonProperty("merge_commit")]
        public object MergeCommit { get; set; }

        [JsonProperty("closed_by")]
        public object ClosedBy { get; set; }
    }

    public partial class Destination
    {
        [JsonProperty("commit")]
        public Commit Commit { get; set; }

        [JsonProperty("repository")]
        public Repository Repository { get; set; }

        [JsonProperty("branch")]
        public Branch Branch { get; set; }
    }

    public partial class Commit
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Links for interactive with commit or get additional information about it
        /// </summary>
        [JsonProperty("links")]
        public Dictionary<string, Link> Links { get; set; }
    }

    public partial class Participant
    {
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("participated_on")]
        public object ParticipatedOn { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("approved")]
        public bool Approved { get; set; }

        [JsonProperty("user")]
        public UserInfo User { get; set; }
    }

    public partial class Rendered
    {
        [JsonProperty("description")]
        public Summary Description { get; set; }

        [JsonProperty("title")]
        public Summary Title { get; set; }
    }

    public partial class Summary
    {
        [JsonProperty("raw")]
        public string Raw { get; set; }

        [JsonProperty("markup")]
        public string Markup { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
