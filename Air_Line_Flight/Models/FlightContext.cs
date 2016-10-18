using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Air_Line_Flight.Models
{
    public class FlightContext : DbContext
    {
        public FlightContext() : base("DefaultConnection")
        { }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Flight> Flights { get; set; }
       // public DbSet<Admin> Admins { get; set; }
       // public DbSet<RegisterViewModel> RegisterViewModelss { get; set; }
    }
}