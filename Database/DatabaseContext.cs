using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using InvoiceApp.Model;
using Microsoft.Extensions.Logging;
namespace InvoiceApp.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CurrencyExchange> CurrencyExchanges { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string solutionFolder = @"C:\Users\kikig\Source\Repos\PS_41_KirilValkov\InvoiceApp\bin\Debug\net9.0-windows";
            //string databaseFile = "Welcome1.db";
            //string databasePath = Path.Combine(solutionFolder, databaseFile);
            //optionsBuilder.UseSqlite($"Data Source={databasePath}");
            optionsBuilder.UseSqlite($"Data Source=InvoiceApp.db");
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Items>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CurrencyExchange>().Property(e => e.Id).ValueGeneratedOnAdd();

            // Create a customer
            var customer1 = new Customer()
            {
                Id = 1,
                Name = "John Doe",
                Bulstat = "BG1234",
                Address = "Sofia Mladost"
            };
            var customer2 = new Customer()
            {
                Id = 2,
                Name = "Testic Testevic",
                Bulstat = "BG2132",
                Address = "Plovdiv 1"
            };
           

            modelBuilder.Entity<Customer>().HasData(customer1);
            modelBuilder.Entity<Customer>().HasData(customer2);

            var USDTOBGN = new CurrencyExchange()
            {
                Id = 1,
                FromCurrency = CurrencyEnum.USD,
                ToCurrency = CurrencyEnum.BGN,
                Rate = 1.8
            };
            modelBuilder.Entity<CurrencyExchange>().HasData(USDTOBGN);
            var EURTOBGN = new CurrencyExchange()
            {
                Id = 2,
                FromCurrency = CurrencyEnum.EUR,
                ToCurrency = CurrencyEnum.BGN,
                Rate = 1.95583
            };
            modelBuilder.Entity<CurrencyExchange>().HasData(EURTOBGN);
            var EURTOUSD = new CurrencyExchange()
            {
                Id = 3,
                FromCurrency = CurrencyEnum.EUR,
                ToCurrency = CurrencyEnum.USD,
                Rate = 1.1
            };
            modelBuilder.Entity<CurrencyExchange>().HasData(EURTOUSD);
            var USDTOEUR = new CurrencyExchange()
            {
                Id = 4,
                FromCurrency = CurrencyEnum.USD,
                ToCurrency = CurrencyEnum.EUR,
                Rate = 0.9
            };
            modelBuilder.Entity<CurrencyExchange>().HasData(USDTOEUR);
            var BGNTOEUR = new CurrencyExchange()
            {
                Id = 5,
                FromCurrency = CurrencyEnum.BGN,
                ToCurrency = CurrencyEnum.EUR,
                Rate = 0.51
            };
            modelBuilder.Entity<CurrencyExchange>().HasData(BGNTOEUR);
            var BGNTOUSD = new CurrencyExchange()
            {
                Id = 6,
                FromCurrency = CurrencyEnum.BGN,
                ToCurrency = CurrencyEnum.USD,
                Rate = 0.56
            };
            modelBuilder.Entity<CurrencyExchange>().HasData(BGNTOUSD);
        }
    }
}
