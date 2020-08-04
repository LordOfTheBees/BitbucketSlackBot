using Bitbucket.AuthenticationClients;
using Bitbucket.BitbucketClients;
using Bitbucket.Data.EnumTypes;
using Bitbucket.Interfaces.BitbucketClients;
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
    [Route("Bitbucket/Repository")]
    public class BRepositoryController : ControllerBase
    {
        private readonly ILogger<BRepositoryController> _logger;

        IBitbucketRepositoryClient _bitbucketClient = null;
        BitbucketAuthConfig _authConfig = null;
        BitbucketRepoConfig _repoConfig = null;

        public BRepositoryController(ILogger<BRepositoryController> logger, IOptions<BitbucketAuthConfig> authConfig, IOptions<BitbucketRepoConfig> repoConfig)
        {
            _logger = logger;
            _authConfig = authConfig.Value;
            _repoConfig = repoConfig.Value;
            _bitbucketClient = new BitbucketClient(new BasicAuthenticationClient(_authConfig.ClientID, _authConfig.ClientPassword));
        }

        [HttpGet]
        public async Task<object> GetRepository([FromQuery]RepositoryRole? role)
        {
            return role.HasValue
                ? await _bitbucketClient.GetRepositories(role.Value)
                : await _bitbucketClient.GetRepositories();
        }

        [HttpGet("{workspace}")]
        public async Task<object> GetRepository(string workspace, [FromQuery]RepositoryRole? role)
        {
            return role.HasValue
                ? await _bitbucketClient.GetRepositories(workspace, role.Value)
                : await _bitbucketClient.GetRepositories(workspace);
        }

        [HttpGet("{workspace}/{repo_slug}")]
        public async Task<object> GetRepository(string workspace, string repo_slug)
        {
            return await _bitbucketClient.GetRepository(workspace, repo_slug);
        }
    }
}
