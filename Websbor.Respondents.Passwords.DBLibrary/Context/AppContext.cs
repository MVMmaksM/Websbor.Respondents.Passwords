using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Websbor.Respondents.Passwords.DBLibrary.Configuration;


namespace DBLibrary.Context
{
    public class AppContext : DbContext
    {
        public DbSet<Model.Passwords> Passwords { get; set; }
        public DbSet<WebsborGS> WebsborGs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.ConnectionString);
        }
    }
}
