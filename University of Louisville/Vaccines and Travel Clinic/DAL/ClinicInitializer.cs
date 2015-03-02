using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Vaccines_and_Travel_Clinic.Models;
using System.Data.SqlTypes;

namespace Vaccines_and_Travel_Clinic.DAL
{
    public class ClinicInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ClinicContext>
    {
        protected override void Seed(ClinicContext context)
        {
            var supplier = new List<Supplier>
            {
                new Supplier{ Company = "ABC Company", FirstName = "John", LastName = "Doe", Phone = "111-111-1111", Address = "123 This Way", City = "Louisville", State = "Kentucky", Zip = "40228", Country = "United States" },
                new Supplier{ Company = "DEF Company", FirstName = "Jane", LastName = "Doe", Phone = "222-222-2222", Address = "456 This Way", City = "Louisville", State = "Kentucky", Zip = "40228", Country = "United States" },
                new Supplier{ Company = "GHI Company", FirstName = "Jack", LastName = "Doe", Phone = "333-333-3333", Address = "789 This Way", City = "Louisville", State = "Kentucky", Zip = "40228", Country = "United States" },
                new Supplier{ Company = "JKL Company", FirstName = "Joe", LastName = "Doe", Phone = "444-444-4444", Address = "987 This Way", City = "Louisville", State = "Kentucky", Zip = "40228", Country = "United States" },
                new Supplier{ Company = "MNO Company", FirstName = "Jill", LastName = "Doe", Phone = "555-555-5555", Address = "654 This Way", City = "Louisville", State = "Kentucky", Zip = "40228", Country = "United States" }
            };

            supplier.ForEach(s => context.Suppliers.Add(s));
            context.SaveChanges();

            var order = new List<Order>
            {
                new Order{ Date = DateTime.Now.AddDays(-1), SupplierID = 1 },
                new Order{ Date = DateTime.Now.AddDays(-2), SupplierID = 2 },
                new Order{ Date = DateTime.Now.AddDays(-3), SupplierID = 3 },
                new Order{ Date = DateTime.Now.AddDays(-4), SupplierID = 4 },
                new Order{ Date = DateTime.Now.AddDays(-5), SupplierID = 5 }
            };

            order.ForEach(o => context.Orders.Add(o));
            context.SaveChanges();

            var item = new List<Item>
            {
                new Item{ Name = "Vaccine One", Description = "ABCDE", Count = 100, Price = 10.00M },
                new Item{ Name = "Vaccine Two", Description = "FGHIJ", Count = 200, Price = 20.00M },
                new Item{ Name = "Vaccine Three", Description = "KLMNO", Count = 300, Price = 30.00M },
                new Item{ Name = "Vaccine Four", Description = "PQRST", Count = 400, Price = 40.00M },
                new Item{ Name = "Vaccine Five", Description = "UVWXY", Count = 500, Price = 50.00M }
            };

            item.ForEach(i => context.Items.Add(i));
            context.SaveChanges();

            var orderline = new List<OrderLine>
            {
                new OrderLine{ OrderID = 1, ItemID = 1, Quantity = 11, Price = 100.00M },
                new OrderLine{ OrderID = 2, ItemID = 2, Quantity = 22, Price = 200.00M },
                new OrderLine{ OrderID = 3, ItemID = 3, Quantity = 33, Price = 300.00M },
                new OrderLine{ OrderID = 4, ItemID = 4, Quantity = 44, Price = 400.00M },
                new OrderLine{ OrderID = 5,ItemID = 5, Quantity = 55, Price = 500.00M },
            };

            orderline.ForEach(ol => context.OrderLines.Add(ol));
            context.SaveChanges();

            var location = new List<Location>
            {
                new Location{ Name = "Location One", Description = "ZYXWV", Address = "123 That Way", City = "Louisville", State = "Kentucky", Zip = "40228", Country = "United States" },
                new Location{ Name = "Location Two", Description = "UTSRQ", Address = "456 That Way", City = "Louisville", State = "Kentucky", Zip = "40228", Country = "United States" },
                new Location{ Name = "Location Three", Description = "PONML", Address = "789 That Way", City = "Louisville", State = "Kentucky", Zip = "40228", Country = "United States" },
                new Location{ Name = "Location Four", Description = "KJIHG", Address = "987 That Way", City = "Louisville", State = "Kentucky", Zip = "40228", Country = "United States" },
                new Location{ Name = "Location Five", Description = "FEDCB", Address = "654 That Way", City = "Louisville", State = "Kentucky", Zip = "40228", Country = "United States" }
            };

            location.ForEach(l => context.Locations.Add(l));
            context.SaveChanges();

            var customer = new List<Customer>
            {
                new Customer{ Secure_City = "Louisville", Secure_State = "Kentucky", Secure_Zip = "40228", Secure_Country = "United States", Secure_Race = "Caucasion", Secure_Age = 11, Secure_Gender = "Male", Secure_Origin = "Italy" },
                new Customer{ Secure_City = "Louisville", Secure_State = "Kentucky", Secure_Zip = "40228", Secure_Country = "United States", Secure_Race = "African American", Secure_Age = 22, Secure_Gender = "Female", Secure_Origin = "France" },
                new Customer{ Secure_City = "Louisville", Secure_State = "Kentucky", Secure_Zip = "40228", Secure_Country = "United States", Secure_Race = "Hispanic", Secure_Age = 33, Secure_Gender = "Male", Secure_Origin = "Germany" },
                new Customer{ Secure_City = "Louisville", Secure_State = "Kentucky", Secure_Zip = "40228", Secure_Country = "United States", Secure_Race = "Mongolian", Secure_Age = 44, Secure_Gender = "Female", Secure_Origin = "Spain" },
                new Customer{ Secure_City = "Louisville", Secure_State = "Kentucky", Secure_Zip = "40228", Secure_Country = "United States", Secure_Race = "Asian", Secure_Age = 55, Secure_Gender = "Male", Secure_Origin = "Ireland" },
            };

            customer.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();

            var sale = new List<Sale>
            {
                new Sale{ Date = DateTime.Now.AddDays(-1), LocationID = 1, CustomerID = 1 },
                new Sale{ Date = DateTime.Now.AddDays(-2), LocationID = 2, CustomerID = 2 },
                new Sale{ Date = DateTime.Now.AddDays(-3), LocationID = 3, CustomerID = 3 },
                new Sale{ Date = DateTime.Now.AddDays(-4), LocationID = 4, CustomerID = 4 },
                new Sale{ Date = DateTime.Now.AddDays(-5), LocationID = 5, CustomerID = 5 }
            };

            sale.ForEach(s => context.Sales.Add(s));
            context.SaveChanges();

            var saleline = new List<SaleLine>
            {
                new SaleLine{ SaleID = 1, ItemID = 1, Quantity = 1, Price = 10.00M },
                new SaleLine{ SaleID = 2, ItemID = 2, Quantity = 2, Price = 20.00M },
                new SaleLine{ SaleID = 3, ItemID = 3, Quantity = 3, Price = 30.00M },
                new SaleLine{ SaleID = 4, ItemID = 4, Quantity = 4, Price = 40.00M },
                new SaleLine{ SaleID = 5, ItemID = 5, Quantity = 5, Price = 50.00M }
            };

            saleline.ForEach(sl => context.SaleLines.Add(sl));
            context.SaveChanges();
        }
    }
}