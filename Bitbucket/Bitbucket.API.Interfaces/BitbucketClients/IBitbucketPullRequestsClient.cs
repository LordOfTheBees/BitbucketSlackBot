using Bitbucket.API.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bitbucket.API.Interfaces.BitbucketClients
{
    public interface IBitbucketPullRequestsClient
    {
        /// <summary>
        /// Returns a list of all pull requests.
        /// For more detailed information about pull request use <see cref="GetPullRequest(string, string, int)"/>
        /// </summary>
        /// <param name="workspace"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        Task<List<PullRequestInfo>> GetAllPullRequestsAsync(string workspace, string repository);

        /// <summary>
        /// Returns detailed information about pull request.
        /// </summary>
        /// <param name="workspace"></param>
        /// <param name="repository"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<PullRequestInfo> GetPullRequestAsync(string workspace, string repository, int id);
    }
}
