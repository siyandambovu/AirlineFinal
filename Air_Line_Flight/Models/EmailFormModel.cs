using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Air_Line_Flight.Models
{
    public class EmailFormModel
    {
        //public MailAddress to { get; set; }
        public List<MailAddress> to { get; set; }

        public MailAddress from { get; set; }
        //public HttpPostedFileBase Upload { get; set; }

        public string sub { get; set; }

        public string body { get; set; }
        public bool isHTML { get; set; }

        public string ToAdmin()
        {
            string message = "E-Mail has not been sent";
            try
            {
                SmtpClient client = new SmtpClient();

                client.Host = "localhost";
                client.Port = 25;
                client.Credentials = new NetworkCredential("", "");
                //client.EnableSsl = true;
                //client.Credentials = new NetworkCredential("", "");
                //client.Host = "smpt.gmail.com";
                //client.Port=587;


                MailMessage mail = new MailMessage();
                mail.From = from;

                foreach (MailAddress m in to)
                {
                    mail.To.Add(m);
                }
                mail.Body = body;
                mail.Subject = sub;
                mail.IsBodyHtml = isHTML;

                message = "E-Mail has been sent";
                client.Send(mail);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
