using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Air_Line_Flight.Models
{
    public class MessageService
    {
        public async static Task SendEmailAsync(string email,string subject, string message)
        {
            try
            {
                var _email = "sbokzasihle@gmail.com";
                var _epass = ConfigurationManager.AppSettings["EmailPassword"];
                var _dispName = "Air_Line Bookings";
                MailMessage myMessage = new MailMessage();
                myMessage.To.Add(email);
                myMessage.From = new MailAddress(_email, _dispName);
                myMessage.Subject = subject;
                myMessage.Body = message;
                myMessage.IsBodyHtml = true;

                using (SmtpClient smpt = new SmtpClient())
                {
                    smpt.EnableSsl = true;
                    smpt.Host = "smtp.gmail.com";
                    smpt.Port = 587;
                    smpt.UseDefaultCredentials = false;
                    smpt.Credentials = new NetworkCredential(_email,_epass);
                    smpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smpt.SendCompleted += (s, e) => { smpt.Dispose(); };
                    await smpt.SendMailAsync(myMessage);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}