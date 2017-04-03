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
    public class ReviewController : Controller
    {
        // GET: News/Review
        public ActionResult Create()
        {
            return View("Edit", new Review());
        }

        // GET: News/Review
        [AllowAnonymous]
        public ActionResult Show(int id)
        {
            Review news = (new ApplicationDbContext()).Review.First(x => x.Id == id);
            return View(news);
        }

        // POST: News/Review
        [HttpPost]
        public ActionResult Edit(Review worker, HttpPostedFileBase image1)
        {

            ApplicationDbContext context = new ApplicationDbContext();
            if (worker.Id != 0)
            {
                var UpdateWorker = context.Review.Where(c => c.Id == worker.Id).FirstOrDefault();
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
                TempData["message"] = string.Format("Изменения в данных о отзыве \"{0}\" были сохранены", worker.Name);
                return RedirectToAction("GetReviewList", "Admin");
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
                cnt.Review.Add(worker);
                cnt.SaveChanges();
                TempData["message"] = string.Format("Отзыв \"{0}\" был добавлен", worker.Name);
                return RedirectToAction("GetReviewList", "Admin");
            }
        }

        [AllowAnonymous]
        public FileContentResult GetImage(int Id)
        {
            ApplicationDbContext cnt = new ApplicationDbContext();
            Review worker = cnt.Review
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
            Review worker = (new ApplicationDbContext()).Review.First(x => x.Id == id);
            return View(worker);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var deleteNews = context.Review.Where(c => c.Id == id).FirstOrDefault();
            context.Entry(deleteNews).State = EntityState.Deleted;
            context.SaveChanges();
            TempData["message"] = string.Format("Отзыв {0} был удален", deleteNews.Name);
            return RedirectToAction("GetReviewList", "Admin");
        }
    }
}
