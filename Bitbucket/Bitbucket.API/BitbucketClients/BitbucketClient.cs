using Bitbucket.API.Data;
using Bitbucket.API.Interfaces.AuthenticationClients;
using Bitbucket.API.Interfaces.BitbucketClients;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bitbucket.API.BitbucketClients
{
    public class BitbucketClient : IBitbucketPullRequestsClient, IDisposable
    {
        private HttpClient _client = null;
        private IAuthenticationClient _authenticationClient = null;

        public BitbucketClient(IAuthenticationClient authenticationClient)
        {
            _authenticationClient = authenticationClient;
            _client = _authenticationClient.CreateHttpClient();
        }

        public void Dispose()
        {
            _client.Dispose();
        }


        #region IBitbucketPullRequests

        public async Task<List<PullRequestInfo>> GetAllPullRequestsAsync(string workspace, string repository)
        {
            string resultJsonString = string.Empty;
            using (var request = _authenticationClient.GetHttpRequest(string.Format(@"https://api.bitbucket.org/2.0/repositories/{0}/{1}/pullrequests", workspace, repository)))
            {
                var response = await _client.SendAsync(request).ConfigureAwait(true);
                resultJsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
            }

            JToken jsonObject = JsonConvert.DeserializeObject<JToken>(resultJsonString);
            var result = JsonConvert.DeserializeObject<List<PullRequestInfo>>(jsonObject["values"].ToString());
            
            return result;
        }

        public async Task<PullRequestInfo> GetPullRequestAsync(string workspace, string repository, int id)
        {
            string resultJsonString = string.Empty;
            using (var request = _authenticationClient.GetHttpRequest(string.Format(@"https://api.bitbucket.org/2.0/repositories/{0}/{1}/pullrequests/{2}", workspace, repository, id)))
            {
                var response = await _client.SendAsync(request).ConfigureAwait(true);
                resultJsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(true);
            }

            return JsonConvert.DeserializeObject<PullRequestInfo>(resultJsonString);
        }

        #endregion // IBitbucketPullRequests
    }
}
