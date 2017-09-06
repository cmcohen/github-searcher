using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubSearcher.api
{
    public class Repo
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string Language { get; set; }

        [JsonProperty("stargazers_count")]
        public int Stars { get; set; }

        [JsonProperty("watchers_count")]
        public int Watchers { get; set; }
    }
}
