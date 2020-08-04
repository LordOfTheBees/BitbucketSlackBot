using Bitbucket.Data;
using Bitbucket.Data.EnumTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bitbucket.Interfaces.BitbucketClients
{
    public interface IBitbucketRepositoryClient
    {
        /// <summary>
        /// Get a list of all public repositories
        /// </summary>
        /// <returns></returns>
        Task<List<Repository>> GetRepositories();

        /// <summary>
        /// Get a list of repositories where the current authentication user has <paramref name="repositoryRole"/>
        /// </summary>
        /// <param name="repositoryRole">role of user</param>
        /// <returns></returns>
        Task<List<Repository>> GetRepositories(RepositoryRole repositoryRole);

        /// <summary>
        /// Get a list of all repositories from workspace
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        Task<List<Repository>> GetRepositories(string workspace);

        /// <summary>
        /// Get a list of all repositories from workspace where the current authentication user has <paramref name="repositoryRole"/>
        /// </summary>
        /// <param name="workspace"></param>
        /// <param name="repositoryRole">role of user</param>
        /// <returns></returns>
        Task<List<Repository>> GetRepositories(string workspace, RepositoryRole repositoryRole);

        /// <summary>
        /// Get information about repository
        /// </summary>
        /// <param name="workspace"></param>
        /// <param name="repoSlug"></param>
        /// <returns></returns>
        Task<Repository> GetRepository(string workspace, string repoSlug);

    }
}
