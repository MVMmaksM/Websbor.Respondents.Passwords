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
            optionsBuilder.UseSqlServer(DbSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passwords>().HasKey(p => p.Id).HasName("PK_Passwords");
            modelBuilder.Entity<Passwords>().Property(p => p.Okpo).HasMaxLength(14);
            modelBuilder.Entity<Passwords>().Property(p => p.DateCreate).HasMaxLength(10);
            modelBuilder.Entity<Passwords>().HasIndex(p => p.Okpo);

            modelBuilder.Entity<WebsborGS>().HasKey(w => w.Id).HasName("PK_WebsborGS");
            modelBuilder.Entity<WebsborGS>().HasIndex(w => w.OkpoGS).IsUnique().HasName("UQ_Websbor_OkpoGS");
            modelBuilder.Entity<WebsborGS>().Property(w => w.OkpoGS).HasMaxLength(14);
            modelBuilder.Entity<WebsborGS>().Property(w => w.OkpoUlGS).HasMaxLength(14);
            modelBuilder.Entity<WebsborGS>().Property(w => w.Inn).HasMaxLength(10);
        }
    }
}
