using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankDataLayer;

namespace Bank_Project_3_4
{
    class ClientPasswordCheck
    {
        HttpRequest _httpRequest = new HttpRequest();

        public async Task<int> validatePassword(String pPassword, String pIban)
        {
            return await _httpRequest.httpGetRequest($"{pPassword}/{pIban}");
        }
    }
}