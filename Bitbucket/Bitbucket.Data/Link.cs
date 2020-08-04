using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitbucket.Data
{
    public class Link
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Name { get; set; }
    }
}
