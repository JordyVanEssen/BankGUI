﻿namespace BankDataLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ClientContext : DbContext
    {
        public ClientContext()
            : base("name=ClientContext")
        {
            Database.SetInitializer<ClientContext>(new CreateDatabaseIfNotExists<ClientContext>());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
