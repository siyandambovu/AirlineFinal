using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Air_Line_Flight.Models;
using System.Data.Entity;
using System.Net;
using Air_Line_Flight.Controllers;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Air_Line_Flight.Controllers
{
    public class AdminController : Controller
    {
        private FlightContext Fdb = new FlightContext();

        //private ApplicationDbContext fc = new ApplicationDbContext();
        


        
        [HttpGet]
        public ActionResult AdminListUsers()
        {
            
            //return View(fc.RegisterViewModels.ToList());
                return View(Fdb.Flights.ToList());
            
        }

        //[HttpGet]
        //public ActionResult AdminsList()
        //{
        //    return View(fc.RegisterViewModels.ToList());
        //}

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}