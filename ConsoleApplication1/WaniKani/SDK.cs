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

        public void requestData<T>(string apiResource, string argument, Action<T> responseHandler) where T : IWaniKaniResponse, new()
        {
            string requestURI = this.requestURI(apiResource, argument);
            HttpClient client = SDK.client;

            Console.WriteLine("Sending Request for " + apiResource + " " + argument);
            HttpResponseMessage httpResponse = client.GetAsync(requestURI).Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                var wanikaniResponse = httpResponse.Content.ReadAsAsync<T>().Result;
                wanikaniResponse.httpResponse = httpResponse;
                responseHandler(wanikaniResponse);
            }
            else
            {
                T wanikaniResponse = new T();
                wanikaniResponse.httpResponse = httpResponse;
                responseHandler(wanikaniResponse);
            }
        }

        public void requestRadicals(Action<RadicalsResponse> responseHandler)
        {
            string apiResource = "radicals";
            string argument = "";

            requestData<RadicalsResponse>(apiResource, argument, responseHandler);
        }

        public void requestKanji(Action<KanjiResponse> responseHandler)
        {
            string apiResource = "kanji";
            string argument = "";

            requestData<KanjiResponse>(apiResource, argument, responseHandler);
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
