﻿using System;
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
            int max = 28;
            //new receipt
            String receipt = "";

            for (int i = 0; i < max; i++)
            {
                receipt += "=";
            }

            receipt += '\n';
            receipt += $"IBAN:\t\t {_currentClient.Iban} \n";

            for (int i = 0; i < max - 3; i++)
            {
                receipt += "--";
            }

            receipt += '\n';
            receipt += $"Oud Saldo:\t\t €{_transaction.OldSaldo} \n";
            receipt += $"Nieuw Saldo:\t\t €{_transaction.NewSaldo} \n";

            for (int i = 0; i < max - 3; i++)
            {
                receipt += "--";
            }

            receipt += "\n";

            if (withdraw)
            {
                if (_amountOfBills > 1)
                {
                    receipt += $"{_amountOfBills} biljetten van:\t {_bill}\n{_billCombination} \n";
                }
                else
                {
                    receipt += $"{_amountOfBills} biljet van:\t {_bill}\n{_billCombination} \n";
                }
            }
           
            for (int i = 0; i < max - 3; i++)
            {
                receipt += "--";
            }

            receipt += '\n';
            receipt += $"Time\t {_transaction.Time.ToLocalTime()} \n";

            for (int i = 0; i < max; i++)
            {
                receipt += "=";
            }

            return receipt;
        }
    }
}