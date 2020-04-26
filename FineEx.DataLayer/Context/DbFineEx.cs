using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FineEx.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace FineEx.DataLayer.Context
{
    public class DbFineEx : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Item> Items { get; set; }
    }
}
