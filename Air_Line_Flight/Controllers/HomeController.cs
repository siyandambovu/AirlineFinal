using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Air_Line_Flight.Models;

namespace Air_Line_Flight.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(FormCollection form)
        {

            string from = form["email"];
            string subj = form["subject"];
            string body = form["message"];
            if (from == "")
            {
                ViewBag.email = "fill in your email";
            }
            if (subj == "")
            {
                ViewBag.subj = "fill in your subject";
            }
            if (body == "")
            {
                ViewBag.body = "fill in your message";
            }
            else
            {
                body += body + " from " + from;
                EmailFormModel obj = new EmailFormModel();
                obj.from = new MailAddress(from);
                List<MailAddress> tolist = new List<MailAddress>();
                tolist.Add(new MailAddress("sbokza1996@gmail.com"));



                obj.to = tolist;
                obj.body = body;
                obj.sub = subj;

                ViewBag.err = "" + obj.ToAdmin() + "";

            }

            return View();
        }
    }
}