using Bitbucket.AuthenticationClients;
using Bitbucket.BitbucketClients;
using Bitbucket.Data.EnumTypes;
using Bitbucket.Interfaces.BitbucketClients;
using BitbucketSlackBot.Configs;
using BitbucketSlackBot.Controllers.Bitbucket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Controllers.Slack
{
    [Route("Slack/Repository")]
    public class SRepositoryController: ControllerBase
    {
        private readonly ILogger<SRepositoryController> _logger;

        IBitbucketRepositoryClient _bitbucketClient = null;
        BitbucketAuthConfig _authConfig = null;
        BitbucketRepoConfig _repoConfig = null;

        public SRepositoryController(ILogger<SRepositoryController> logger, IOptions<BitbucketAuthConfig> authConfig, IOptions<BitbucketRepoConfig> repoConfig)
        {
            _logger = logger;
            _authConfig = authConfig.Value;
            _repoConfig = repoConfig.Value;
            _bitbucketClient = new BitbucketClient(new BasicAuthenticationClient(_authConfig.ClientID, _authConfig.ClientPassword));
        }

        [HttpGet]
        public async Task<object> GetRepository(string clientId, string clientPassword)
        {
            _logger.LogInformation("GetRepository");
            var client = new BitbucketClient(new BasicAuthenticationClient(clientId, clientPassword));
            return (await client.GetRepositories(RepositoryRole.Member)).Select(repo => repo.FullName);
        }
    }
}
