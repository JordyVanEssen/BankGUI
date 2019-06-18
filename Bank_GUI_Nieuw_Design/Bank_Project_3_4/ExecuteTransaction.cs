using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using BankDataLayer;
using Bank_Project_3_4.ViewModels;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace Bank_Project_3_4
{
    public class ExecuteTransaction
    {
        SerialPort _sp;
        private String _currentClientNuid;
        private HttpRequest _httpRequest;
        private PrintReceipt _print;

        private String _chosenBill = String.Empty;
        private int _billValue = 0;
        private String _billCombination = "";
        private int _status = -1;

        //the bills to choose from
        private int[] _bill = { 10, 20, 50 };

        public ExecuteTransaction(String pNuid, SerialPort pSp)
        {
            _sp = pSp;
            _currentClientNuid = pNuid;
        }

        public async Task<int> executeTransaction(String pBill, String pAmount)
        {
            if (!string.IsNullOrEmpty(pBill) && !string.IsNullOrEmpty(pAmount))
            {
                int amount = Convert.ToInt32(pAmount.Replace("R", ""));

                if (!string.IsNullOrEmpty(pBill))
                {
                    _chosenBill = pBill.Replace("R", "");
                    _billValue = Convert.ToInt32(_chosenBill);

                    //withdraw
                    if (((double)amount / (double)_billValue) % 1 == 0)
                    {
                        if (_billValue == 10)
                            _sp.Write("$1");

                        else if (_billValue == 20)
                            _sp.Write("%1");

                        else if (_billValue == 50)
                            _sp.Write("&1");

                        Thread.Sleep(2500);

                        _httpRequest = new HttpRequest("Withdraw", $"{_currentClientNuid}/ATM/{amount}");
                        _status = await HttpRequest.withdrawAsync(_httpRequest.createUrl());
                    }
                    else
                    {
                       _status = await alternativeBilloption(amount);
                    }

                    _print = new PrintReceipt(_currentClientNuid, pBill, Convert.ToInt32(amount / _billValue), _billCombination);
                }
            }
            return _status;
        }

        private async Task<int> alternativeBilloption(double pAmount)
        {
            int[][] wantedBills = { };
            _billCombination = "";
            int x = 0;
            int rest = 0;
            int billCount = 0;
            int a = _bill.Length;
            int previousBill = 0;
            int withdrawAmount = Convert.ToInt32(pAmount);

            while (pAmount >= _billValue)
            {
                x++;
                pAmount -= _billValue;
            }

            billCount = x;
            x = 0;
            rest = Convert.ToInt32(pAmount);

            for (int i = 0; i < 100; i++)
            {
                a--;

                if (rest >= _bill[a])
                {
                    if (previousBill == _bill[a])
                    {
                        x++;
                    }
                    else
                    {
                        x = 1;
                    }

                    if (_bill[a] == 10)
                        _sp.Write("$1");

                    else if (_bill[a] == 20)
                        _sp.Write("%1");

                    else if (_bill[a] == 50)
                        _sp.Write("&1");


                    previousBill = _bill[a];
                    rest -= _bill[a];
                    a++;
                }

                if (a == 0)
                {
                    if (rest <= 4)
                        break;

                    //i = 0;
                    a = _bill.Length;
                }
            }

            if (rest != 0)
            {
                withdrawAmount -= rest;       
            }
            _httpRequest = new HttpRequest("Withdraw", $"{_currentClientNuid}/ATM/{withdrawAmount}");
            return await HttpRequest.withdrawAsync(_httpRequest.createUrl());
        }
    
        //prints the receipt on screen
        public async Task<String> printReceipt()
        {
            if (_status == 0)
            {
                String receipt = await _print.print();
                return receipt;
            }
            return "";
        }

    }
}
