using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using BankDataLayer;

namespace Bank_Project_3_4
{
    public class CheckUserSaldo
    {
        HttpRequest _httpRequest;
        String _userTagId;
        Client _currentClient = new Client();
        double usersaldo = 0;

        public CheckUserSaldo(Client pCurrentClient, String pUserTagId)
        {
            _userTagId = pUserTagId;
            _currentClient = pCurrentClient;
        }

        //returns the saldo of the current user
        public double getSaldo()
        {
            //getUser();
            usersaldo = _currentClient.Saldo;
            return usersaldo;
        }

        public async void getUser()
        {
            _httpRequest = new HttpRequest("ClientItems", _userTagId);
            _currentClient = await HttpRequest.GetClientAsync(_httpRequest.createUrl());
        }
    }
}
