using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bitbucket.Data
{
    public class Branch
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
