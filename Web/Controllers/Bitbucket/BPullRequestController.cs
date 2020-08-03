using Bitbucket.API.AuthenticationClients;
using Bitbucket.API.BitbucketClients;
using Bitbucket.API.Data;
using Bitbucket.API.Interfaces.BitbucketClients;
using BitbucketSlackBot.Configs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Controllers.Bitbucket
{
    [ApiController]
    [Route("Bitbucket/PullRequest")]
    public class BPullRequestController : ControllerBase
    {
        private readonly ILogger<BPullRequestController> _logger;

        IBitbucketPullRequestsClient _bitbucketClient = null;
        BitbucketAuthConfig _authConfig = null;
        BitbucketRepoConfig _repoConfig = null;

        public BPullRequestController(ILogger<BPullRequestController> logger, IOptions<BitbucketAuthConfig> authConfig, IOptions<BitbucketRepoConfig> repoConfig)
        {
            _logger = logger;
            _authConfig = authConfig.Value;
            _repoConfig = repoConfig.Value;
            _bitbucketClient = new BitbucketClient(new BasicAuthenticationClient(_authConfig.ClientID, _authConfig.ClientPassword));
        }

        [HttpGet]
        public async Task<object> Get(int? id)
        {
            if (id.HasValue)
                return await GetPullRequest(id.Value);
            else
                return await GetAllPullRequests();
        }



        private async Task<PullRequestInfo> GetPullRequest(int id) => await _bitbucketClient.GetPullRequestAsync(_repoConfig.Workspace, _repoConfig.RepositoryName, id);
        private async Task<IEnumerable<PullRequestInfo>> GetAllPullRequests() => await _bitbucketClient.GetAllPullRequestsAsync(_repoConfig.Workspace, _repoConfig.RepositoryName);
    }
}
