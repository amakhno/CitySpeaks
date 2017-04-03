using CitySpeaks_samle.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitySpeaks_samle.Controllers
{
    [Authorize]
    public class MainPageController : Controller
    {
        // GET: MainPage
        [HttpPost]
        public ActionResult Edit(MainPage mainPage, HttpPostedFileBase image1, HttpPostedFileBase image2)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            if ((mainPage.Id != 0) && (context.MainPage.Where(c => c.Id == 1).FirstOrDefault() != null))
            {
                var UpdateMainPage = context.MainPage.Where(c => c.Id == 1).FirstOrDefault();
                if ((image1 == null && UpdateMainPage.MainImageData == null) || (image2 == null && UpdateMainPage.LogolImageData == null) || !ModelState.IsValid)
                {
                    TempData["message"] = "Не получены изображения";
                    return View(mainPage);
                }
                if (image1 != null)
                {
                    UpdateMainPage.MainImageMimeType = image1.ContentType;
                    UpdateMainPage.MainImageData = new byte[image1.ContentLength];
                    image1.InputStream.Read(UpdateMainPage.MainImageData, 0, image1.ContentLength);
                }
                if (image2 != null)
                {
                    UpdateMainPage.LogoImageMimeType = image2.ContentType;
                    UpdateMainPage.LogolImageData = new byte[image2.ContentLength];
                    image2.InputStream.Read(UpdateMainPage.LogolImageData, 0, image2.ContentLength);
                }
                UpdateMainPage.Title = mainPage.Title;
                UpdateMainPage.Subtitle = mainPage.Subtitle;
                UpdateMainPage.Description = mainPage.Description;
                context.Entry(UpdateMainPage).State = EntityState.Modified;
                context.SaveChanges();
                TempData["message"] = string.Format("Изменения были сохранены");
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                if ((image1 == null) || (image2 == null ) || !ModelState.IsValid)
                {
                    TempData["message"] = "Не получены изображения";
                    return View(mainPage);
                }

                mainPage.MainImageMimeType = image1.ContentType;
                mainPage.MainImageData = new byte[image1.ContentLength];
                image1.InputStream.Read(mainPage.MainImageData, 0, image1.ContentLength);


                mainPage.LogoImageMimeType = image2.ContentType;
                mainPage.LogolImageData = new byte[image2.ContentLength];
                image2.InputStream.Read(mainPage.LogolImageData, 0, image2.ContentLength);

                ApplicationDbContext cnt = new ApplicationDbContext();
                cnt.MainPage.Add(mainPage);
                cnt.SaveChanges();
                TempData["message"] = string.Format("Оформление было добавлено");
                return RedirectToAction("Index", "Admin");
            }
        }

        [AllowAnonymous]
        public FileContentResult GetMainImage(int newsId)
        {
            ApplicationDbContext cnt = new ApplicationDbContext();
            MainPage mainPage = cnt.MainPage
                .FirstOrDefault(g => g.Id == newsId);

            if (mainPage != null && mainPage.MainImageData != null)
            {
                return File(mainPage.MainImageData, mainPage.MainImageMimeType);
            }
            else
            {
                return null;
            }
        }

        [AllowAnonymous]
        public FileContentResult GetLogoImage(int newsId)
        {
            ApplicationDbContext cnt = new ApplicationDbContext();
            MainPage mainPage = cnt.MainPage
                .FirstOrDefault(g => g.Id == newsId);

            if (mainPage != null && mainPage.LogolImageData != null)
            {
                return File(mainPage.LogolImageData, mainPage.LogoImageMimeType);
            }
            else
            {
                return null;
            }
        }


        // GET: News/Edit/5
        public ActionResult Edit(int id = 1)
        {
            if (id == 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var mainPage = (new ApplicationDbContext()).MainPage;
                if (mainPage.Where(x=>x.Id == id).Count() == 0)
                {
                    return View(new MainPage());
                }
                return View(mainPage.FirstOrDefault());
            }
        }
    }
}