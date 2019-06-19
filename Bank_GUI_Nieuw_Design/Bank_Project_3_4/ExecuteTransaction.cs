using System;
using System.Linq;
using System.Threading.Tasks;
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
        private String _password = string.Empty;

        private String[] _wantedBills = new String[4] { "", "", "", "" };
        private int _billCount = 0;
        private int _index = 0;


        //the bills to choose from
        private int[] _bill = { 10, 20, 50 };

        public ExecuteTransaction(String pNuid, SerialPort pSp, String pPassword)
        {
            _password = pPassword;
            _sp = pSp;
            _currentClientNuid = pNuid;
        }

        public ExecuteTransaction(String pNuid, String pPassword)
        {
            _password = pPassword;
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
                        if (_sp != null)
                        {
                            if (_billValue == 10)
                                _sp.Write("$1");

                            else if (_billValue == 20)
                                _sp.Write("%1");

                            else if (_billValue == 50)
                                _sp.Write("&1");
                        }
                        _httpRequest = new HttpRequest("Withdraw", $"{_currentClientNuid}/ATM/{amount}/{_password}");
                        _status = await HttpRequest.withdrawAsync(_httpRequest.createUrl());

                        _httpRequest = new HttpRequest("BillItems", $"{_billValue}/1");
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
            _index = 0;
            int withdrawAmount = Convert.ToInt32(pAmount);

            while (pAmount >= _billValue)
            {
                _billCount++;
                pAmount -= _billValue;
            }

            addBillToArray(_billValue, _billCount);

            while (pAmount >= _bill.Last())
            {
                _billCount++;
                pAmount -= _bill.Last();

            }
            while (pAmount >= _bill[1])
            {
                _billCount++;
                pAmount -= _bill[1];
            }
            addBillToArray(_bill[1], _billCount);


            while (pAmount >= _bill[0])
            {
                _billCount++;
                pAmount -= _bill[0];
            }
            addBillToArray(_bill[0], _billCount);

            if (pAmount != 0)
            {
                withdrawAmount -= (int)pAmount;       
            }

            for (int i = 0; i < _wantedBills.Length; i++)
            {
                _sp.Write(_wantedBills[i]);
                Thread.Sleep(4000);
            }

            _httpRequest = new HttpRequest("Withdraw", $"{_currentClientNuid}/ATM/{withdrawAmount}/{_password}");
            return await HttpRequest.withdrawAsync(_httpRequest.createUrl());
        }

        public async void addBillToArray(int pBillVal, int pAmount)
        {
            _billCount = 0;
            if (_index == 0)
            {
                for (int i = 0; i < _wantedBills.Length; i++)
                {
                    if (_wantedBills.Length > 0)
                    {
                        _wantedBills[i] = string.Empty;
                    }
                }
            }

            String bill = string.Empty;

            if (pBillVal == 10)
                bill = $"${pAmount}";
            else if (pBillVal == 20)
                bill = $"%{pAmount}";
            else if (pBillVal == 50)
                bill = $"&{pAmount}";

            _httpRequest = new HttpRequest("BillItems", $"{pBillVal}/{pAmount}");
            _status = await HttpRequest.withdrawAsync(_httpRequest.createUrl());

            _wantedBills[_index] = bill;
            _index++;
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
