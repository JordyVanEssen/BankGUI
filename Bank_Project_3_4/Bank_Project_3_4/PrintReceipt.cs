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

        public PrintReceipt( Transaction pTransaction, Client pCClient)
        {
            _currentClient = pCClient;
            _transaction = pTransaction;
        }

        //creates the receipt and returns it
        public String print()
        {
            //new receipt
            String receipt = "";

            for (int i = 0; i < 39; i++)
            {
                receipt += "=";
            }

            receipt += '\n';
            receipt += "Client name\t " + _transaction.Name + '\n';
            receipt += "IBAN     \t " + _currentClient.Iban + '\n';

            for (int i = 0; i < 39; i++)
            {
                receipt += "--";
            }

            receipt += '\n';
            receipt += "Old Saldo\t\t " + _transaction.OldSaldo + '\n';
            receipt += "New Saldo\t " + _transaction.NewSaldo + '\n';

            for (int i = 0; i < 39; i++)
            {
                receipt += "--";
            }

            receipt += '\n';
            receipt += "Time     \t " + _transaction.Time + '\n';

            for (int i = 0; i < 39; i++)
            {
                receipt += "=";
            }

            return receipt;
        }
    }
}
