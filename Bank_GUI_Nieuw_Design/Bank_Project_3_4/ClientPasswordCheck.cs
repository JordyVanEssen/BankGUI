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
            int response = 0;
            _httpRequest = new HttpRequest("Authentication");
            response = await HttpRequest.AuthenticationAsync(_httpRequest.createUrl(), $"{pPassword}/{pNuid}");
            /*
            if (pNuid.Contains("PILS"))
            {
                _httpRequest = new HttpRequest("Authentication");
                response = await HttpRequest.AuthenticationAsync(_httpRequest.createUrl(), $"{pPassword}/{pNuid}");
            }
            else
            {
                String bankCode = pNuid.Substring(4, 8);
                CentralBankConnection cbc = new CentralBankConnection();
                CentralBankConnection.sendCommand($"\"{bankCode}\", \"PILS\", \"pinCheck\", \"{pNuid}\", \"{pPassword}\"");
            }
            */

            if (response == 1)
            {
                return true;
            }
            return false;
        }
    }
}