using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WaniKani
{
    public class SDK
    {
        public const string baseURL = "https://www.wanikani.com/api/user/";
        private string apiKey = "";

        public SDK(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public void requestRadicals(Action<WaniKaniResponse> responseHandler)
        {
            string apiResource = "radicals";
            string argument = "";

            string requestURI = this.requestURI(apiResource, argument);
            HttpClient client = SDK.client;

            Console.WriteLine("Sending Request for " + apiResource + " " + argument);
            HttpResponseMessage httpResponse = client.GetAsync(requestURI).Result;  // Blocking call!
            if (httpResponse.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var radicalsResponse = httpResponse.Content.ReadAsAsync<RadicalsResponse>().Result;
                radicalsResponse.httpResponse = httpResponse;

                responseHandler(radicalsResponse);
            }
            else
            {
                RadicalsResponse radicalsResponse = new RadicalsResponse();
                radicalsResponse.httpResponse = httpResponse;
                responseHandler(radicalsResponse);
            }
        }

        public void requestKanji(Action<WaniKaniResponse> responseHandler)
        {
            string apiResource = "kanji";
            string argument = "";

            string requestURI = this.requestURI(apiResource, argument);
            HttpClient client = SDK.client;

            Console.WriteLine("Sending Request for " + apiResource + " " + argument);
            HttpResponseMessage httpResponse = client.GetAsync(requestURI).Result;  // Blocking call!
            if (httpResponse.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var kanjiResponse = httpResponse.Content.ReadAsAsync<KanjiResponse>().Result;
                kanjiResponse.httpResponse = httpResponse;

                responseHandler(kanjiResponse);
            }
            else
            {
                KanjiResponse kanjiResponse = new KanjiResponse();
                kanjiResponse.httpResponse = httpResponse;
                responseHandler(kanjiResponse);
            }
        }

        private string requestURI(string apiResource, string argument)
        {
            return apiKey + "/" + apiResource + "/" + argument;
        }

        private static HttpClient client
        {
            get
            {
                HttpClient _client = new HttpClient();
                _client.BaseAddress = new Uri(SDK.baseURL);
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return _client;
            }
        }
    }
}
