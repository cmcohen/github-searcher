using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GitHubSearcher.api
{
    public class GitHubSearcherApi
    {
        public User GetUser(string username)
        {
            using (var client = new WebClient())
            {
                client.Headers["User-Agent"] = "hello";

                .string result = client.DownloadString($"https://api.github.com/users/{username}");
                User user = JsonConvert.DeserializeObject<User>(result);
                return user; 
            }
        }
        
        public IEnumerable<Repo> GetUserRepos(string username)
        {
            using (var client = new WebClient())
            {
                client.Headers["User-Agent"] = "hello";
                string result = client.DownloadString($"https://api.github.com/users/{username}/repos");
                IEnumerable<Repo> repos = JsonConvert.DeserializeObject<IEnumerable<Repo>>(result);
                return repos;
            }          
        }    
          
    }
}
