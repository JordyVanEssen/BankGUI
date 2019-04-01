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
        Transaction _transaction;
        Client _currentClient;
        String _bill;
        int _amountOfBills;
        Boolean withdraw = false;
        String _billCombination = "";

        public PrintReceipt(Transaction pTransaction, Client pCClient, String pBill, int pBillCount, String pBillCombination)
        {
            _billCombination = pBillCombination;
            _currentClient = pCClient;
            _transaction = pTransaction;
            _bill = pBill;
            _amountOfBills = pBillCount;
            withdraw = true;
        }

        public PrintReceipt(Transaction pTransaction, Client pCClient)
        {
            _currentClient = pCClient;
            _transaction = pTransaction;
            withdraw = false;
        }

        //creates the receipt and returns it
        public String print()
        {
            String iban = _currentClient.Iban.Substring(0, 11);
            int max = 42;
            String receipt = "";

            //creates a new receipt
            for (int i = 0; i < max; i++)
            {
                receipt += "=";
            }

            receipt += '\n';
            receipt += $"IBAN:\t\t\t {iban}*** \n";

            for (int i = 0; i < max - 4; i++)
            {
                receipt += "--";
            }

            receipt += '\n';
            receipt += $"Oud Saldo:\t\t €{_transaction.OldSaldo} \n";
            receipt += $"Nieuw Saldo:\t\t €{_transaction.NewSaldo} \n";

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
            receipt += $"Tijd:\t\t\t {_transaction.Time.ToLocalTime()} \n";

            for (int i = 0; i < max; i++)
            {
                receipt += "=";
            }

            return receipt;
        }
    }
}
