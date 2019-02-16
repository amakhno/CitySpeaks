using CitySpeaks.Domain.Models;
using CitySpeaks.Persistence;
using CitySpeaks.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CitySpeaks.WebUI.Controllers
{
    [Authorize]
    public class ReviewController : BaseController
    {
        private readonly CitySpeaksContext _citySpeaksContext;

        public ReviewController(CitySpeaksContext citySpeaksContext)
        {
            _citySpeaksContext = citySpeaksContext;
        }

        // GET: Review/Create
        public ActionResult Create()
        {
            return View("Edit", new Review());
        }

        // GET: Review/Show
        [AllowAnonymous]
        public ActionResult Show(int id)
        {
            Review news = _citySpeaksContext.Reviews.First(x => x.Id == id);
            return View(news);
        }

        // POST: Review/Edit
        [HttpPost]
        public ActionResult Edit(Review review, IFormFile image)
        {
            if (review.Id != 0)
            {
                var UpdateWorker = _citySpeaksContext.Reviews.Include(x => x.Image).Where(c => c.Id == review.Id).FirstOrDefault();
                if ((image == null && UpdateWorker.Image == null) || !ModelState.IsValid)
                {
                    TempData["message"] = "Что-то пошло не так, проверьте ввод еще раз";
                    return View(review);
                }
                int? imageToDelete = null;
                if (image != null)
                {
                    if (UpdateWorker.Image != null)
                    {
                        imageToDelete = UpdateWorker.Image.Id;
                    }
                    UpdateWorker.Image = ImageHelpers.GetImageFromIFile(image);
                }
                UpdateWorker.Name = review.Name;
                UpdateWorker.ShortDescription = review.ShortDescription;
                _citySpeaksContext.Entry(UpdateWorker).State = EntityState.Modified;
                _citySpeaksContext.SaveChanges();
                TempData["message"] = string.Format("Изменения в данных о отзыве \"{0}\" были сохранены", review.Name);
                return RedirectToAction("GetReviewList", "Admin");
            }
            else
            {
                if (image != null)
                {
                    review.Image = ImageHelpers.GetImageFromIFile(image);
                }
                _citySpeaksContext.Reviews.Add(review);
                _citySpeaksContext.SaveChanges();
                TempData["message"] = string.Format("Отзыв \"{0}\" был добавлен", review.Name);
                return RedirectToAction("GetReviewList", "Admin");
            }
        }

        [AllowAnonymous]
        public FileContentResult GetImage(int Id)
        {
            Review worker = _citySpeaksContext.Reviews.Include(x => x.Image)
                .FirstOrDefault(g => g.Id == Id);

            if (worker != null && worker.Image?.ImageData != null)
            {
                return File(worker.Image.ImageData, worker.Image.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            Review review = _citySpeaksContext.Reviews
                .Include(x => x.Image).First(x => x.Id == id);
            return View(review);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int id)
        {
            var deleteNews = _citySpeaksContext.Reviews
                .Where(c => c.Id == id).FirstOrDefault();
            _citySpeaksContext.Entry(deleteNews).State = EntityState.Deleted;
            _citySpeaksContext.SaveChanges();
            TempData["message"] = string.Format("Отзыв {0} был удален", deleteNews.Name);
            return RedirectToAction("GetReviewList", "Admin");
        }
    }
}
