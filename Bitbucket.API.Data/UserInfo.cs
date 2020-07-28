using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bitbucket.API.Data
{
    public class UserInfo
    {
            [JsonProperty("display_name")]
            public string DisplayName { get; set; }

            [JsonProperty("uuid")]
            public string Uuid { get; set; }

            [JsonProperty("nickname")]
            public string Nickname { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("account_id")]
            public string AccountId { get; set; }

            /// <summary>
            /// Links for interactive with user or get additional information about him
            /// </summary>
            [JsonProperty("links")]
            public Dictionary<string, Link> Links { get; set; }
    }
}
