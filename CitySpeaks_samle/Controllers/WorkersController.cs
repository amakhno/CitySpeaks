using CitySpeaks_samle.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CitySpeaks_samle.Controllers
{
    public class WorkersController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        // GET: News/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View("Edit", new Workers());
        }

        // GET: News/Create
        public ActionResult Show(int id)
        {
            Workers news = (new ApplicationDbContext()).Workers.First(x => x.Id == id);
            return View(news);
        }

        // POST: News/Create
        [HttpPost]
        public ActionResult Edit(Workers worker, HttpPostedFileBase image1)
        {

            ApplicationDbContext context = new ApplicationDbContext();
            if (worker.Id != 0)
            {
                var UpdateWorker = context.Workers.Where(c => c.Id == worker.Id).FirstOrDefault();
                if ((image1 == null && UpdateWorker.ImageData == null) || !ModelState.IsValid)
                {
                    TempData["message"] = "Что-то пошло не так, проверьте ввод еще раз";
                    return View(worker);
                }
                if (image1 != null)
                {
                    UpdateWorker.ImageMimeType = image1.ContentType;
                    UpdateWorker.ImageData = new byte[image1.ContentLength];
                    image1.InputStream.Read(UpdateWorker.ImageData, 0, image1.ContentLength);
                }
                UpdateWorker.Name = worker.Name;
                UpdateWorker.ShortDescription = worker.ShortDescription;
                context.Entry(UpdateWorker).State = EntityState.Modified;
                context.SaveChanges();
                TempData["message"] = string.Format("Изменения в данных о работнике \"{0}\" были сохранены", worker.Name);
                return RedirectToAction("GetWorkersList", "Admin");
            }
            else
            {
                if (image1 != null)
                {
                    worker.ImageMimeType = image1.ContentType;
                    worker.ImageData = new byte[image1.ContentLength];
                    image1.InputStream.Read(worker.ImageData, 0, image1.ContentLength);
                }
                ApplicationDbContext cnt = new ApplicationDbContext();
                cnt.Workers.Add(worker);
                cnt.SaveChanges();
                TempData["message"] = string.Format("Работник \"{0}\" был добавлен", worker.Name);
                return RedirectToAction("GetWorkersList", "Admin");
            }
        }

        public FileContentResult GetImage(int Id)
        {
            ApplicationDbContext cnt = new ApplicationDbContext();
            Workers worker = cnt.Workers
                .FirstOrDefault(g => g.Id == Id);

            if (worker != null && worker.ImageData != null)
            {
                return File(worker.ImageData, worker.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        // GET: News/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            Workers worker = (new ApplicationDbContext()).Workers.First(x => x.Id == id);
            return View(worker);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var deleteNews = context.Workers.Where(c => c.Id == id).FirstOrDefault();
            context.Entry(deleteNews).State = EntityState.Deleted;
            context.SaveChanges();
            TempData["message"] = string.Format("Данные о работнике {0} были удалены", deleteNews.Name);
            return RedirectToAction("GetWorkersList", "Admin");
        }

        // POST: News/Delete/5
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
