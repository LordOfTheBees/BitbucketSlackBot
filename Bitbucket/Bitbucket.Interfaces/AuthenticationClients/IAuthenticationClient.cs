using System.Net.Http;

namespace Bitbucket.Interfaces.AuthenticationClients
{
    public interface IAuthenticationClient
    {
        /// <summary>
        /// Creates a GET HTTP request with the necessary headers
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        HttpRequestMessage GetHttpRequest(string uri);

        /// <summary>
        /// Creates an HTTP client with the necessary headers
        /// </summary>
        /// <returns></returns>
        HttpClient CreateHttpClient();
    }
}
