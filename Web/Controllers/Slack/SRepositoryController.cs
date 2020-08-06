using Bitbucket.AuthenticationClients;
using Bitbucket.BitbucketClients;
using Bitbucket.Data.EnumTypes;
using Bitbucket.Interfaces.BitbucketClients;
using BitbucketSlackBot.Configs;
using BitbucketSlackBot.Controllers.Bitbucket;
using BitbucketSlackBot.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitbucketSlackBot.Controllers.Slack
{
    [Route("Slack/Repository")]
    public class SRepositoryController: ControllerBase
    {
        private readonly ILogger<SRepositoryController> _logger;

        private IBitbucketRepositoryClient _bitbucketClient = null;
        private BitbucketAuthConfig _authConfig = null;
        private BitbucketRepoConfig _repoConfig = null;
        private BitbucketSlackDataContext _dataBaseContext;

        public SRepositoryController(ILogger<SRepositoryController> logger, IOptions<BitbucketAuthConfig> authConfig, IOptions<BitbucketRepoConfig> repoConfig, BitbucketSlackDataContext dataBaseContext)
        {
            _logger = logger;
            _authConfig = authConfig.Value;
            _repoConfig = repoConfig.Value;
            _bitbucketClient = new BitbucketClient(new BasicAuthenticationClient(_authConfig.ClientID, _authConfig.ClientPassword));
            _dataBaseContext = dataBaseContext;

        }

        [HttpPost]
        public async Task<object> GetRepository(string clientId, string clientPassword)
        {
            _logger.LogInformation("GetRepository");
            var client = new BitbucketClient(new BasicAuthenticationClient(clientId, clientPassword));
            return (await client.GetRepositories(RepositoryRole.Member)).Select(repo => repo.FullName);
        }


        [HttpPost("Test")]
        public async Task<object> PostRepositoryTest()
        {
            _logger.LogInformation("GetRepositoryTest");
            _logger.LogInformation(await (new StreamReader(this.Request.Body)).ReadToEndAsync());
            return Ok();
        }


        [HttpGet("Test")]
        public async Task<object> GetTest()
        {
           // var user2 = _dataBaseContext.SlackUsers.FirstOrDefault(usr => usr.SlackUserID == 2);
           // var user3 = _dataBaseContext.SlackUsers.FirstOrDefault(usr => usr.SlackUserID == 2);
            //var team = _dataBaseContext.SlackTeams.FirstOrDefault(tm => tm.SlackTeamID == 1);
            return Ok();
        }
    }
}
