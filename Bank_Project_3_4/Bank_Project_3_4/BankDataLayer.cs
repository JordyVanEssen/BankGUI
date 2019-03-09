﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankDataLayer
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public String Password { get; set; }
        public string PassId { get; set; }
        public double Saldo { get; set; }
        public Boolean PassBlocked { get; set; }

        public virtual List<Transaction> Transactions { get; set; }
    }

    public class Transaction
    {
        public int TransactionId { get; set; }
        public string Name { get; set; }
        public string Iban { get; set; }
        public double OldSaldo { get; set; }
        public double NewSaldo { get; set; }
        public DateTime Time { get; set; }

        public virtual Client Client { get; set; }
    }

    public partial class ClientContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
