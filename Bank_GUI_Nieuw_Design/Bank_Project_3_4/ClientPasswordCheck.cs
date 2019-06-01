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
        HttpRequest _httpRequest;

        public async Task<Boolean> validatePassword(String pPassword, String pNuid)
        {
            _httpRequest = new HttpRequest("Authentication");
            int response = await HttpRequest.AuthenticationAsync(_httpRequest.createUrl(), $"{pPassword}/{pNuid}");

            if (response == 1)
            {
                return true;
            }
            return false;
        }
    }
}