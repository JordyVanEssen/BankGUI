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
using BankDataLayer;

namespace Bank_Project_3_4
{
    class PrintReceipt
    {
        String _currentClientIban;
        String _bill;
        int _amountOfBills;
        Boolean withdraw = false;
        String _billCombination = "";

        public PrintReceipt(String pIban, String pBill, int pBillCount, String pBillCombination)
        {
            _billCombination = pBillCombination;
            _currentClientIban = pIban;
            _bill = pBill;
            _amountOfBills = pBillCount;
            withdraw = true;
        }

        public PrintReceipt(String pIban)
        {
            _currentClientIban = pIban;
            withdraw = false;
        }

        //creates the receipt and returns it
        public async Task<String> print()
        {
            HttpRequest _httpRequest = new HttpRequest("ClientSaldo", $"{_currentClientIban}");
            int saldo = await HttpRequest.getSaldoAsync(_httpRequest.createUrl());
            String iban = _currentClientIban.Substring(10, 4);
            int max = 38;
            String receipt = "";

            //creates a new receipt
            for (int i = 0; i < max; i++)
            {
                receipt += "=";
            }

            receipt += '\n';
            receipt += $"IBAN:\t\t\t **********{iban} \n";

            for (int i = 0; i < max - 4; i++)
            {
                receipt += "--";
            }

            receipt += '\n';
            receipt += $"Nieuw Saldo:\t\t €{saldo} \n";

            for (int i = 0; i < max - 4; i++)
            {
                receipt += "--";
            }                     

            receipt += "\n";

            if (withdraw)
            {
                if (_amountOfBills > 1 || _amountOfBills == 0)
                {
                    receipt += $"{_amountOfBills} biljetten van:\t\t {_bill}\n{_billCombination} \n";
                }
                else
                {
                    receipt += $"{_amountOfBills} biljet van:\t\t {_bill}\n{_billCombination} \n";
                }
            }
           
            for (int i = 0; i < max - 4; i++)
            {
                receipt += "--";
            }

            receipt += '\n';
            receipt += $"Tijd:\t\t\t {DateTime.Now.ToString("HH:mm:ss tt")} \n";

            for (int i = 0; i < max; i++)
            {
                receipt += "=";
            }

            return receipt;
        }
    }
}
