using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitySpeaks_samle.Models;
using System.Net.Mail;
using System.Net;

namespace CitySpeaks_samle.Controllers
{
    public class ContactController : Controller
    {
        [HttpPost]
        public ActionResult Index(Contact contact)
        {

            ApplicationDbContext context = new ApplicationDbContext();           

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("mail@u0330659.plsk.regruhosting.ru");
                mail.To.Add(new MailAddress("mail@u0330659.plsk.regruhosting.ru"));
                mail.Subject = "Заголовок";
                mail.Body = "Cjj,otybt";
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

            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            else return RedirectToAction("Index", "Home");
        }

        // GET: News/Edit/5
        public ActionResult Index()
        {
            return View(new Contact());
        }
    }
}