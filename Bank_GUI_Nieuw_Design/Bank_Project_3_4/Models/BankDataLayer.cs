using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Bank_Project_3_4.Models;

namespace BankDataLayer
{
    public class Client
    {
        public int ClientId { get; set; }
        public int UserTagId { get; set; }
        public string Name { get; set; }
        public double Saldo { get; set; }
        public string Iban { get; set; }

        public Transaction Transaction { get; set; }
    }

    public class Transaction
    {
        public int TransactionId { get; set; }
        public int ClientId { get; set; }
        public String Name { get; set; }
        public String Iban { get; set; }
        public String IbanDestination { get; set; }
        public String Mode { get; set; }
        public int Amount { get; set; }
        public DateTime Time { get; set; }
    }

    public class UserTag
    {
        public int UsertagId { get; set; }
        public String Password { get; set; }
        public string PassId { get; set; }
        public Boolean PassBlocked { get; set; }
        public int invalidPasswordCount { get; set; }

        public Client Client { get; set; }
    }

    class MessageQueue
    {
        public int MessageId { get; set; }
        public String Function { get; set; }
        public String DataObject { get; set; }
        public int StatusCode { get; set; }
        public Boolean Finished { get; set; }
        public Boolean ValidPassword { get; set; }
        public String Message { get; set; }
    }

    public partial class ClientContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<UserTag> UserTags { get; set; }
    }
}
