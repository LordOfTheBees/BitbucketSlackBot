using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitbucket.Data
{
    public class Repository
    {
        [JsonProperty("scm")]
        public string Scm { get; set; }

        [JsonProperty("website")]
        public object Website { get; set; }

        [JsonProperty("has_wiki")]
        public bool HasWiki { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("links")]
        public RepositoryLinks Links { get; set; }

        [JsonProperty("fork_policy")]
        public string ForkPolicy { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("project")]
        public Project Project { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("created_on")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("mainbranch")]
        public Branch Mainbranch { get; set; }

        [JsonProperty("workspace")]
        public Project Workspace { get; set; }

        [JsonProperty("has_issues")]
        public bool HasIssues { get; set; }

        [JsonProperty("owner")]
        public UserInfo Owner { get; set; }

        [JsonProperty("updated_on")]
        public DateTimeOffset UpdatedOn { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class RepositoryLinks
    {
        [JsonProperty("watchers")]
        public Link Watchers { get; set; }

        [JsonProperty("branches")]
        public Link Branches { get; set; }

        [JsonProperty("tags")]
        public Link Tags { get; set; }

        [JsonProperty("commits")]
        public Link Commits { get; set; }

        [JsonProperty("clone")]
        public Link[] Clone { get; set; }

        [JsonProperty("self")]
        public Link Self { get; set; }

        [JsonProperty("source")]
        public Link Source { get; set; }

        [JsonProperty("html")]
        public Link Html { get; set; }

        [JsonProperty("avatar")]
        public Link Avatar { get; set; }

        [JsonProperty("hooks")]
        public Link Hooks { get; set; }

        [JsonProperty("forks")]
        public Link Forks { get; set; }

        [JsonProperty("downloads")]
        public Link Downloads { get; set; }

        [JsonProperty("issues")]
        public Link Issues { get; set; }

        [JsonProperty("pullrequests")]
        public Link Pullrequests { get; set; }
    }
}
