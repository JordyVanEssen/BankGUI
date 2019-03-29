using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.Entity;
using System.Net.Http;
using BankDataLayer;
using System.Net;

namespace Bank_Project_3_4
{
    class HttpRequest
    {
        private static readonly HttpClient httpClient = new HttpClient();

        // url + controller + parameters, 'https://localhost:44396/api/ClientItems/1'
        private String _url = "https://localhost:44396/api/";
        private String _urlController = "";
        private object _urlPrameter = "";

        public HttpRequest(String pController, String pParameter)
        {
            _urlController = pController + "/";
            _urlPrameter = pParameter;
        }

        public HttpRequest(String pController)
        {
            _urlController = pController + "/";
        }

        public String createUrl()
        {
            _url = _url += _urlController += _urlPrameter;
            return _url;
        }

        //http get Usertag request
        public static async Task<ReturnObject> GetUserTagAsync(String path)
        {
            ReturnObject user = null;
            //String nuidAuthenticationString = "";
            HttpResponseMessage response = await httpClient.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<ReturnObject>();
            }
            return user;
        }

        //http get Client request
        public static async Task<Client> GetClientAsync(String path)
        {
            Client user = null;
            HttpResponseMessage response = await httpClient.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<Client>();
            }
            return user;
        }

        //http authentication
        public static async Task<int> AuthenticationAsync(String path, String pPassword)
        {
            int valid = 0;//1'true' or 0'false'
            HttpResponseMessage response = await httpClient.GetAsync(path + pPassword);

            if (response.IsSuccessStatusCode)
            {
                valid = await response.Content.ReadAsAsync<int>();
            }
            return valid;
        }

        //http create
        public static async Task<Object> CreateAsync(Object pClient, String pPath)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(pPath, pClient);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response;
        }

        //http update
        public static async Task<HttpStatusCode> UpdateClientAsync(Client pClientItem, String pPath)
        {
            HttpResponseMessage response = await httpClient.PutAsJsonAsync(pPath + $"{pClientItem.ClientId}", pClientItem);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            //pClient = await response.Content.ReadAsAsync<Client>();
            return response.StatusCode;
        }

        //http update
        public static async Task<HttpStatusCode> UpdateUserTagAsync(UserTag pUserItem, String pPath)
        {
            HttpResponseMessage response = await httpClient.PutAsJsonAsync(pPath + $"{pUserItem.UsertagId}", pUserItem);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            //pClient = await response.Content.ReadAsAsync<Client>();
            return response.StatusCode;
        }
    }
}
