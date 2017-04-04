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
    public class CustomPageController : Controller
    {
        // GET: CustomPage/Create
        public ActionResult Create()
        {
            return View("Edit", new CustomPage());
        }

        // GET: CustomPage/Create
        [AllowAnonymous]
        public ActionResult Show(int id)
        {
            CustomPage CustomPage = (new ApplicationDbContext()).CustomPage.First(x => x.Id == id);
            return View(CustomPage);
        }

        // POST: CustomPage/Create
        [HttpPost]
        public ActionResult Edit(CustomPage CustomPage, HttpPostedFileBase image2, bool Show = false)
        {
            CustomPage.IsShow = Show;
            ApplicationDbContext context = new ApplicationDbContext();
            if (CustomPage.Id != 0)
            {
                var UpdateCustomPage = context.CustomPage.Where(c => c.Id == CustomPage.Id).FirstOrDefault();
                if ((image2 == null && UpdateCustomPage.BigImageData == null) || !ModelState.IsValid)
                {
                    TempData["message"] = "Не получены изображения";
                    return View(CustomPage);
                }
                if (image2 != null)
                {
                    UpdateCustomPage.BigImageMimeType = image2.ContentType;
                    UpdateCustomPage.BigImageData = new byte[image2.ContentLength];
                    image2.InputStream.Read(UpdateCustomPage.BigImageData, 0, image2.ContentLength);
                }
                UpdateCustomPage.Name = CustomPage.Name;
                UpdateCustomPage.Page = CustomPage.Page;
                UpdateCustomPage.IsShow = CustomPage.IsShow;
                context.Entry(UpdateCustomPage).State = EntityState.Modified;
                context.SaveChanges();
                TempData["message"] = string.Format("Изменения в странице \"{0}\" были сохранены", CustomPage.Name);
                return RedirectToAction("GetCustomPageList", "Admin");
            }
            else
            {
                if (image2 != null)
                {
                    CustomPage.BigImageMimeType = image2.ContentType;
                    CustomPage.BigImageData = new byte[image2.ContentLength];
                    image2.InputStream.Read(CustomPage.BigImageData, 0, image2.ContentLength);
                }
                ApplicationDbContext cnt = new ApplicationDbContext();
                cnt.CustomPage.Add(CustomPage);
                cnt.SaveChanges();
                TempData["message"] = string.Format("Страница \"{0}\" была создана", CustomPage.Name);
                return RedirectToAction("GetCustomPageList", "Admin");
            }
        }

        [AllowAnonymous]
        public FileContentResult GetBigImage(int Id)
        {
            ApplicationDbContext cnt = new ApplicationDbContext();
            CustomPage game = cnt.CustomPage
                .FirstOrDefault(g => g.Id == Id);

            if (game != null && game.BigImageData != null)
            {
                return File(game.BigImageData, game.BigImageMimeType);
            }
            else
            {
                return null;
            }
        }

        // GET: CustomPage/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            CustomPage CustomPage = (new ApplicationDbContext()).CustomPage.First(x => x.Id == id);
            return View(CustomPage);
        }

        // GET: CustomPage/Delete/5        
        public ActionResult Delete(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var deleteCustomPage = context.CustomPage.Where(c => c.Id == id).FirstOrDefault();
            context.Entry(deleteCustomPage).State = EntityState.Deleted;
            context.SaveChanges();
            TempData["message"] = string.Format("Страница {0} была удалена", deleteCustomPage.Name);
            return RedirectToAction("GetCustomPageList", "Admin");
        }

        [AllowAnonymous]
        public ActionResult GetListOfPages()
        {
            try
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    var db = context.CustomPage.Where(x=>x.IsShow);
                    List<CustomPage> result = new List<Models.CustomPage>();
                    foreach(var page in db)
                    {
                        result.Add(page);
                    }
                    return View(result);
                }
            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult GetListOfCorePages()
        {
            try
            {
                using (ApplicationDbContext context = new ApplicationDbContext())
                {
                    var db = context.CustomPage.Where(x=>!x.IsShow);
                    List<CustomPage> result = new List<Models.CustomPage>();
                    foreach (var page in db)
                    {
                        result.Add(page);
                    }
                    return View(result);
                }
            }
            catch
            {
                return View();
            }
        }
    }
}