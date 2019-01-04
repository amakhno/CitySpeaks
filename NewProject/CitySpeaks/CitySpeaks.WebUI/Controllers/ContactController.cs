using System;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using CitySpeaks.Domain.Models;
using CitySpeaks.WebUI.Models;

namespace CitySpeaks.WebUI.Controllers
{
    public class ContactController : Controller
    {
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            CitySpeaksContext context = new CitySpeaksContext();
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            else
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("mail@u0330659.plsk.regruhosting.ru");
                    mail.To.Add(new MailAddress("mail@u0330659.plsk.regruhosting.ru"));
                    mail.Subject = contact.Theme;
                    mail.Body = String.Format("Имя: {0}\nТелефон: {1}\nПочта: {2}\nСообщение:\n{3}", contact.Name, contact.PhoneNumber, contact.Mail, contact.Message);
                    SmtpClient client = new SmtpClient();
                    client.Host = "u0330659.plsk.regruhosting.ru";
                    client.Port = 587;
                    client.EnableSsl = false;
                    client.Credentials = new NetworkCredential("mail@u0330659.plsk.regruhosting.ru".Split('@')[0], "167943As");
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(mail);
                    mail.Dispose();
                }
                catch (Exception e)
                {
                    throw new Exception("Mail.Send: " + e.Message);
                }
                return RedirectToAction("Success", "Contact");
            }
        }

        // GET: News/Edit/5
        public ActionResult Index()
        {
            return View(new Contact());
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}