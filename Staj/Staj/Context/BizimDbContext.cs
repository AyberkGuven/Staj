using Staj.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Staj.Context
{
    public class BizimDbContext:DbContext
    {
        public BizimDbContext() : base("BizimDBConnectionString")
        {

        }
        public DbSet<Bizim> Bizims { get; set; }
        public DbSet<Core> Cores { get; set; }
        public DbSet<DC> DCs { get; set; }
        public DbSet<Sokak> Sokaks { get; set; }
        public DbSet<Sipliter> Sipliters { get; set; }
        public DbSet<Tup> Tups { get; set; }
        public DbSet<User> Users { get; set; }
    }
}