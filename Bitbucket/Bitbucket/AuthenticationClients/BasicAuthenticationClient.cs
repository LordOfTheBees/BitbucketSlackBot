using Bitbucket.Interfaces.AuthenticationClients;
using System.Net.Http;

namespace Bitbucket.AuthenticationClients
{
    public class BasicAuthenticationClient : IAuthenticationClient
    {
        private string _clientId = string.Empty;
        private string _clientSecret = string.Empty;

        public BasicAuthenticationClient(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        public HttpClient CreateHttpClient()
        {
            return new HttpClient();
        }

        public HttpRequestMessage GetHttpRequest(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            request.Headers.Add(
                "Authorization",
                "Basic " + System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(string.Format("{0}:{1}", _clientId, _clientSecret))));

            return request;
        }
    }
}
