using Bitbucket.API.Data;
using Bitbucket.API.Data.EnumTypes;
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
    public class BitbucketClient : IBitbucketPullRequestsClient, IBitbucketRepositoryClient, IDisposable
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

        #region INTERFACES IMPLEMENTATIONS

        #region IBitbucketRepositoryClient

        public async Task<List<Repository>> GetRepositories()
        {
            return await GetListOfElement<Repository>(@"https://api.bitbucket.org/2.0/repositories").ConfigureAwait(false);
        }

        public async Task<List<Repository>> GetRepositories(RepositoryRole repositoryRole)
        {
            return await GetListOfElement<Repository>(string.Format(@"https://api.bitbucket.org/2.0/repositories?role={0}", repositoryRole)).ConfigureAwait(false);
        }

        public async Task<List<Repository>> GetRepositories(string workspace)
        {
            return await GetListOfElement<Repository>(string.Format(@"https://api.bitbucket.org/2.0/repositories/{0}", workspace)).ConfigureAwait(false);
        }

        public async Task<List<Repository>> GetRepositories(string workspace, RepositoryRole repositoryRole)
        {
            return await GetListOfElement<Repository>(string.Format(@"https://api.bitbucket.org/2.0/repositories/{0}?{1}", workspace, repositoryRole)).ConfigureAwait(false);
        }

        public async Task<Repository> GetRepository(string workspace, string repoSlug)
        {
            return await GetSingleElement<Repository>(string.Format(@"https://api.bitbucket.org/2.0/repositories/{0}/{1}", workspace, repoSlug)).ConfigureAwait(false);
        }

        #endregion // IBitbucketRepositoryClient


        #region IBitbucketPullRequests

        public async Task<List<PullRequestInfo>> GetAllPullRequestsAsync(string workspace, string repository)
        {
            return await GetListOfElement<PullRequestInfo>(string.Format(@"https://api.bitbucket.org/2.0/repositories/{0}/{1}/pullrequests", workspace, repository)).ConfigureAwait(false);
        }

        public async Task<PullRequestInfo> GetPullRequestAsync(string workspace, string repository, int id)
        {
            return await GetSingleElement<PullRequestInfo>(string.Format(@"https://api.bitbucket.org/2.0/repositories/{0}/{1}/pullrequests/{2}", workspace, repository, id)).ConfigureAwait(false);
        }

        #endregion // IBitbucketPullRequests

        #endregion // INTERFACES IMPLEMENTATIONS


        #region PRIVATE METHODS

        private async Task<T> GetSingleElement<T>(string url)
        {
            string resultJsonString = string.Empty;
            using (var request = _authenticationClient.GetHttpRequest(url))
            {
                var response = await _client.SendAsync(request).ConfigureAwait(false);
                resultJsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }

            JToken jsonObject = JsonConvert.DeserializeObject<JToken>(resultJsonString);
            if (jsonObject["type"]?.ToString() == "error") throw new Exception(jsonObject["error"]?.ToString());

            return JsonConvert.DeserializeObject<T>(resultJsonString);
        }

        private async Task<List<T>> GetListOfElement<T>(string url)
        {
            List<T> result = new List<T>();
            string resultJsonString = string.Empty;

            while (!string.IsNullOrEmpty(url))
            {
                using (var requst = _authenticationClient.GetHttpRequest(url))
                {
                    var response = await _client.SendAsync(requst).ConfigureAwait(false);
                    resultJsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }

                JToken jsonObject = JsonConvert.DeserializeObject<JToken>(resultJsonString);
                if (jsonObject["type"]?.ToString() == "error") throw new Exception(jsonObject["error"]?.ToString());

                var tmpList = JsonConvert.DeserializeObject<List<T>>(jsonObject["values"]?.ToString());
                if (tmpList != null) result.AddRange(tmpList);

                url = jsonObject["next"]?.ToString();
            }

            return result;
        }

        #endregion // PRIVATE METHODS
    }
}
