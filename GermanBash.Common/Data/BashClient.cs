using GermanBash.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GermanBash.Common.Data
{
    public class BashClient : IBashClient
    {
        #region Members

        private const string BASE_SERVICE_URI = "http://bsautermeister.de/german-bash0r/api/service.php";
        private const string BASE_WEBSITE_URI = "http://german-bash.org";

        private const string SERVICE_METHOD = "method";

        private HttpClientHandler HttpClientHandler { get; set; }

        public CookieContainer Cookies
        {
            get { return HttpClientHandler.CookieContainer; }
            set { HttpClientHandler.CookieContainer = value; }
        }

        private HttpClient _httpClient = new HttpClient();

        #endregion

        #region Constructors

        public BashClient()
        {
            HttpClientHandler = new HttpClientHandler
            {
                AllowAutoRedirect = true,
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };
            _httpClient = new HttpClient(HttpClientHandler);
        }

        #endregion

        #region Public Methods

        public async Task<BashCollection> GetQuotesAsync(string order)
        {
            string uriString = String.Format("{0}?{1}={2}",
                BASE_SERVICE_URI, 
                SERVICE_METHOD, order);
            var response = await _httpClient.GetAsync(uriString);
            
            if (response.IsSuccessStatusCode)
            {
                var encodedData = await ReadEncodedContentAsync(response);
                return JsonConvert.DeserializeObject<BashCollection>(encodedData);
            }

            return null;
        }

        public async Task<BashCollection> GetQueryAsync(string term)
        {
            // TODO: escape "term" string?

            string uriString = String.Format("{0}?{1}={2}&{3}={4}",
                BASE_SERVICE_URI, 
                SERVICE_METHOD, AppConstants.METHOD_SEARCH,
                AppConstants.PARAM_TERM, term);
            var response = await _httpClient.GetAsync(uriString);

            if (response.IsSuccessStatusCode)
            {
                var encodedData = await ReadEncodedContentAsync(response);
                return JsonConvert.DeserializeObject<BashCollection>(encodedData);
            }

            return null;
        }

        public async Task<bool> RateAsync(int id, string type)
        {
            string uriString = String.Format("{0}?{1}={2}&{3}={4}%20&{5}={6}",
                BASE_WEBSITE_URI,
                AppConstants.PARAM_ACTION, AppConstants.ACTION_VOTE,
                AppConstants.PARAM_ID, id,
                AppConstants.PARAM_TYPE, type);

            var formData = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>(AppConstants.PARAM_ID, id.ToString()),
                new KeyValuePair<string, string>(AppConstants.PARAM_TYPE, type)
            });

            var response = await _httpClient.PostAsync(uriString, formData);

            if (response.IsSuccessStatusCode)
            {
                var encodedData = await ReadEncodedContentAsync(response);

                if (encodedData != null && encodedData.Length <= 3)
                {
                    // FIXME: currently: "lol" (for spamming protection, because COOKIE data is missing?)
                    // usual correct result: 0, incorrect: -2
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Private Methods

        private static async Task<string> ReadEncodedContentAsync(HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsByteArrayAsync();
            string encodedString = Encoding.GetEncoding("iso-8859-1").GetString(data, 0, data.Length);
            return encodedString;
        }

        #endregion
    }
}
