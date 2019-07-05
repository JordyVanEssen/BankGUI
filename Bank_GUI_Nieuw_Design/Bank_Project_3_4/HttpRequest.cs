using System;
using System.Threading.Tasks;
using System.Net.Http;
using BankDataLayer;
using System.Net;

namespace Bank_Project_3_4
{
    class HttpRequest
    {
        private static readonly HttpClient httpClient = new HttpClient();

        // url + controller + parameters, 'https://debankproject34.azurewebsites.net/api/ClientItems/1'
        private String _url = "https://project34bank.azurewebsites.net/api/";
        //private String _url = "https://localhost:5001/api/";

        public HttpRequest() { }

        public async Task<int> httpGetRequest(String pUrl)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"{_url}{pUrl}");
            return await response.Content.ReadAsAsync<int>();
        }

        //http update MessageQueue
        public async Task<HttpStatusCode> UpdateMessageQueueAsync(MessageQueue pMessage, String pPath)
        {
            HttpResponseMessage response = await httpClient.PutAsJsonAsync($"{_url}{pPath}/{pMessage.MessageId}", pMessage);
            response.EnsureSuccessStatusCode();

            return response.StatusCode;
        }

        //http get the first message in the queueu
        public async Task<MessageQueue> getMessageQueue(String path)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"{_url}{path}");

            if (response.IsSuccessStatusCode)
            {
                MessageQueue mq = await response.Content.ReadAsAsync<MessageQueue>();
                return mq;
            }

            return null;
        }
    }
}
