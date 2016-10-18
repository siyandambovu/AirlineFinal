using Air_Line_Flight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Air_Line_Flight.Controllers
{
    public class FlightController : Controller
    {
        private FlightContext Fdb = new FlightContext();
        //private ApplicationDbContext fc = new ApplicationDbContext();
        public ActionResult flight()
        {
            return View();
        }
        [HttpPost]
        public ActionResult flight(/*[Bind(Include ="Email")]*/ Flight f)
        {
            if (ModelState.IsValid)
            {
                using (Fdb)
                {
                    Fdb.Flights.Add(f);
                    Fdb.SaveChanges();
                }
                ModelState.Clear();

            }
            //Customer ct = new Customer();
            //ViewBag.Message = ct.Name ;
            //return View();
            return RedirectToAction("ListOfBookings");
        }




        // GET: Flight
        public ActionResult Index()
        {
            return View();
        }

        // GET: Flight/Details/5
        public ActionResult Details(int id)
        {
            Flight flight1 = Fdb.Flights.ToList().Find(s => s.flightID == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Flight sbo = Fdb.Flights.Find(id);
            if (flight1 == null)
            {
                return HttpNotFound();
            }

            return View(flight1);
        }

        // GET: Flight/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flight/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        // GET: Flight/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight sbo = Fdb.Flights.Single(e=>e.flightID==id);
            if (sbo == null)
            {
                return HttpNotFound();
            }
            return View(sbo);
        }

        // POST: Flight/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection, [Bind(Include = "Date1,Email,Source,Dest,Number,Adults,Child")] Flight sbo)
        {

            // TODO: Add update logic here

            if (ModelState.IsValid)
            {
                
                Fdb.Entry(sbo).State = System.Data.Entity.EntityState.Modified;
                
                //fc.SaveChanges();
                Fdb.SaveChanges();
                return RedirectToAction("ListOfBookings");
            }
            return View(sbo);

        }

        // GET: Flight/Delete/5
        public ActionResult Delete(int id)
        {
            Flight flg = Fdb.Flights.Find(id);
            return View(flg);
        }

        // POST: Flight/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Flight fl = new Flight();
                if (ModelState.IsValid)
                {
                    fl = Fdb.Flights.Find(id);
                    if (fl == null)
                        return HttpNotFound();
                    Fdb.Flights.Remove(fl);
                    Fdb.SaveChanges();
                    return RedirectToAction("ListOfBookings");
                }
                return View(fl);
            }
            catch
            {
                return View();
            }
        }
        
        [HttpPost]
        public ActionResult ListOfBookings(long s)
        {
            if (s != null)
            {
                long id = Convert.ToInt64(s);
                //return RedirectToAction("Details","Details","Member");
                return View(Fdb.Flights.Where(x => x.flightID == id).ToList());
            }
            return View(Fdb.Flights.Where(x => x.Email == User.Identity.Name).ToList());
        }
        [HttpGet]
        public ActionResult ListOfBookings()
        {
            return View(Fdb.Flights.Where(x => x.Email == User.Identity.Name).ToList());
        }


    }
}
