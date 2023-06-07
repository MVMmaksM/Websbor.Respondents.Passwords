using DbLibrary.Configurations;
using DbLibrary.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLibrary.Context
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Passwords> Passwords { get; set; }
        public DbSet<WebsborGS> WebsborGS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettings.ConnectionString);
        }
    }
}
