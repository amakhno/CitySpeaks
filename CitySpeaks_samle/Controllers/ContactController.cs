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
        [reCAPTCHA.MVC.CaptchaValidator(ErrorMessage = "Не пройдена проверка",
        RequiredMessage = "Пройдите проверку")]
        public ActionResult Index(Contact contact)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            if (!ModelState.IsValid || contact.IsPersonalDataConfirmed == false)
            {
                if (!contact.IsPersonalDataConfirmed)
                {
                    ModelState.AddModelError(nameof(contact.IsPersonalDataConfirmed), "Вы должны подтвердить согласие на обработку персональных данных");
                }
                return View(contact);
            }
            else
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("mail@cityspeaks.ru");
                    mail.To.Add(new MailAddress("mail@cityspeaks.ru"));
                    mail.Subject = contact.Theme;
                    mail.Body = String.Format("Имя: {0}\nТелефон: {1}\nПочта: {2}\nСообщение:\n{3}", contact.Name, contact.PhoneNumber, contact.Mail, contact.Message);
                    SmtpClient client = new SmtpClient();
                    client.Host = "u0330659.plsk.regruhosting.ru";
                    client.Port = 25;
                    client.EnableSsl = false;
                    client.Credentials = new NetworkCredential("mail@cityspeaks.ru".Split('@')[0], "167943As");
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