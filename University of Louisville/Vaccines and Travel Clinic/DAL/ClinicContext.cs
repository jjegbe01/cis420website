using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Vaccines_and_Travel_Clinic.Models;

namespace Vaccines_and_Travel_Clinic.DAL
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(string securityPartition = null, string asRole = null) : base("ClinicContext") 
        {
            Crypteron.CipherDb.Session.Open(this, securityPartition, asRole);
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<SaleLine> SaleLines { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Appointment> Appointment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}