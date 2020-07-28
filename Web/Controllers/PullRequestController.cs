using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bitbucket.API.Interfaces.BitbucketClients;
using Bitbucket.API.AuthenticationClients;
using Bitbucket.API.BitbucketClients;
using Bitbucket.API.Data;
using BitbucketSlackBot.Configs;
using Microsoft.Extensions.Options;

namespace BitbucketSlackBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PullRequestController : ControllerBase
    {
        private readonly ILogger<PullRequestController> _logger;

        IBitbucketPullRequestsClient _bitbucketClient = null;
        BitbucketAuthConfig _authConfig = null;
        BitbucketRepoConfig _repoConfig = null;

        public PullRequestController(ILogger<PullRequestController> logger, IOptions<BitbucketAuthConfig> authConfig, IOptions<BitbucketRepoConfig> repoConfig)
        {
            _logger = logger;
            _authConfig = authConfig.Value;
            _repoConfig = repoConfig.Value;
            _bitbucketClient = new BitbucketClient(new BasicAuthenticationClient(_authConfig.ClientID, _authConfig.ClientPassword));
        }

        [HttpGet]
        public async Task<object> Get(int? id)
        {
            if(id.HasValue)
                return await GetPullRequest(id.Value);
            else
                return await GetAllPullRequests();
        }



        private async Task<PullRequestInfo> GetPullRequest(int id) => await _bitbucketClient.GetPullRequestAsync(_repoConfig.Workspace, _repoConfig.RepositoryName, id);
        private async Task<IEnumerable<PullRequestInfo>> GetAllPullRequests() => await _bitbucketClient.GetAllPullRequestsAsync(_repoConfig.Workspace, _repoConfig.RepositoryName);
    }
}
