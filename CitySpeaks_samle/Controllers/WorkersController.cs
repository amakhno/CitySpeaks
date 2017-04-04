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
    public class WorkersController : Controller
    {
        // GET: Workers/Create
        public ActionResult Create()
        {
            return View("Edit", new Workers());
        }

        // GET: Workers/Create
        [AllowAnonymous]
        public ActionResult Show(int id)
        {
            Workers Workers = (new ApplicationDbContext()).Workers.First(x => x.Id == id);
            return View(Workers);
        }

        // POST: Workers/Create
        public ActionResult Edit(Workers Workers, HttpPostedFileBase image1, HttpPostedFileBase image2)
        {

            ApplicationDbContext context = new ApplicationDbContext();
            if (Workers.Id != 0)
            {
                var UpdateWorkers = context.Workers.Where(c => c.Id == Workers.Id).FirstOrDefault();
                if ((image1 == null && UpdateWorkers.ImageData == null) || (image2 == null && UpdateWorkers.BigImageData == null) || !ModelState.IsValid)
                {
                    TempData["message"] = "Не получены изображения";
                    return View(Workers);
                }
                if (image1 != null)
                {
                    UpdateWorkers.ImageMimeType = image1.ContentType;
                    UpdateWorkers.ImageData = new byte[image1.ContentLength];
                    image1.InputStream.Read(UpdateWorkers.ImageData, 0, image1.ContentLength);
                }
                if (image2 != null)
                {
                    UpdateWorkers.BigImageMimeType = image2.ContentType;
                    UpdateWorkers.BigImageData = new byte[image2.ContentLength];
                    image2.InputStream.Read(UpdateWorkers.BigImageData, 0, image2.ContentLength);
                }
                UpdateWorkers.Name = Workers.Name;
                UpdateWorkers.ShortDescription = Workers.ShortDescription;
                UpdateWorkers.FullDescription = Workers.FullDescription;
                context.Entry(UpdateWorkers).State = EntityState.Modified;
                context.SaveChanges();
                TempData["message"] = string.Format("Изменения в работнике \"{0}\" были сохранены", Workers.Name);
                return RedirectToAction("GetWorkersList", "Admin");
            }
            else
            {
                if (image1 != null)
                {
                    Workers.ImageMimeType = image1.ContentType;
                    Workers.ImageData = new byte[image1.ContentLength];
                    image1.InputStream.Read(Workers.ImageData, 0, image1.ContentLength);
                }
                if (image2 != null)
                {
                    Workers.BigImageMimeType = image2.ContentType;
                    Workers.BigImageData = new byte[image2.ContentLength];
                    image2.InputStream.Read(Workers.BigImageData, 0, image2.ContentLength);
                }
                ApplicationDbContext cnt = new ApplicationDbContext();
                cnt.Workers.Add(Workers);
                cnt.SaveChanges();
                TempData["message"] = string.Format("Работник \"{0}\" был добавлен", Workers.Name);
                return RedirectToAction("GetWorkersList", "Admin");
            }
        }

        [AllowAnonymous]
        public FileContentResult GetBigImage(int WorkersId)
        {
            ApplicationDbContext cnt = new ApplicationDbContext();
            Workers game = cnt.Workers
                .FirstOrDefault(g => g.Id == WorkersId);

            if (game != null && game.BigImageData != null)
            {
                return File(game.BigImageData, game.BigImageMimeType);
            }
            else
            {
                return null;
            }
        }

        [AllowAnonymous]
        public FileContentResult GetImage(int WorkersId)
        {
            ApplicationDbContext cnt = new ApplicationDbContext();
            Workers game = cnt.Workers
                .FirstOrDefault(g => g.Id == WorkersId);

            if (game != null && game.ImageData != null)
            {
                return File(game.ImageData, game.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        // GET: Workers/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            Workers worker = (new ApplicationDbContext()).Workers.First(x => x.Id == id);
            return View(worker);
        }

        // GET: Workers/Delete/5
        public ActionResult Delete(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var deleteWorkers = context.Workers.Where(c => c.Id == id).FirstOrDefault();
            context.Entry(deleteWorkers).State = EntityState.Deleted;
            context.SaveChanges();
            TempData["message"] = string.Format("Данные о работнике {0} были удалены", deleteWorkers.Name);
            return RedirectToAction("GetWorkersList", "Admin");
        }

        // POST: Workers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
