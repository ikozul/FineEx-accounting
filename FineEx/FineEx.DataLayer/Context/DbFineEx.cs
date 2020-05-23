﻿using System.Data.Entity;
using FineEx.DataLayer.Migrations;
using FineEx.DataLayer.Models;
using Microsoft.EntityFrameworkCore;


namespace FineEx.DataLayer.Context
{
    public class DbFineEx : System.Data.Entity.DbContext
    {

        public DbFineEx() : base("DbFineEx")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbFineEx, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //ToDo
        }

        public Microsoft.EntityFrameworkCore.DbSet<Item> Items { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Company> Companies { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }
        //public DbSet<Item> Items { get; set; }

    }
}