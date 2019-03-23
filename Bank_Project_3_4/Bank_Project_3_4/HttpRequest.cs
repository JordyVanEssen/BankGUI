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

        //http get request
        public static async Task<UserTag> GetClientAsync(String path)
        {
            UserTag user = null;
            HttpResponseMessage response = await httpClient.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<UserTag>();
            }
            return user;
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
        public static async Task<HttpStatusCode> UpdateClientAsync(Object pClient, String pPath)
        {
            HttpResponseMessage response = await httpClient.PutAsJsonAsync(pPath, pClient);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            //pClient = await response.Content.ReadAsAsync<Client>();
            return response.StatusCode;
        }
    }
}
