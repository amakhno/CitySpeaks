using CitySpeaks.Application.Workers.Queries;
using CitySpeaks.Domain.Models;
using CitySpeaks.Persistence;
using CitySpeaks.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CitySpeaks.WebUI.Controllers
{
    [Authorize]
    public class WorkersController : BaseController
    {
        private readonly CitySpeaksContext _citySpeaksContext;

        public WorkersController(CitySpeaksContext citySpeaksContext)
        {
            _citySpeaksContext = citySpeaksContext;
        }

        // GET: Workers/Create
        public ActionResult Create()
        {
            return View("Edit", new Worker());
        }

        // GET: Workers/Create
        [AllowAnonymous]
        public ActionResult Show(int id)
        {
            Worker workers = _citySpeaksContext.Workers.First(x => x.Id == id);
            return View(workers);
        }

        [HttpPost]
        // POST: Workers/Create
        public ActionResult Edit(Worker worker, IFormFile smallImage, IFormFile bigImage)
        {
            var context = _citySpeaksContext;
            if (worker.Id != 0)
            {
                var workerFromDb = context.Workers.Include(x => x.BigImage)
                    .Include(x => x.SmallImage).Where(c => c.Id == worker.Id).FirstOrDefault();
                if ((smallImage == null && workerFromDb.SmallImage?.ImageData == null)
                    || (bigImage == null && workerFromDb.BigImage?.ImageData == null) || !ModelState.IsValid)
                {
                    TempData["message"] = "Не получены изображения";
                    return View(worker);
                }
                if (smallImage != null)
                {
                    workerFromDb.SmallImage = ImageHelpers.GetImageFromIFile(smallImage);
                }
                if (bigImage != null)
                {
                    workerFromDb.BigImage = ImageHelpers.GetImageFromIFile(bigImage);
                }
                workerFromDb.Name = worker.Name;
                workerFromDb.ShortDescription = worker.ShortDescription;
                workerFromDb.FullDescription = worker.FullDescription;
                context.SaveChanges();
                TempData["message"] = string.Format("Изменения в работнике \"{0}\" были сохранены", worker.Name);
                return RedirectToAction("GetWorkersList", "Admin");
            }
            else
            {
                if (smallImage != null)
                {
                    worker.SmallImage = ImageHelpers.GetImageFromIFile(smallImage);
                }
                if (bigImage != null)
                {
                    worker.BigImage = ImageHelpers.GetImageFromIFile(bigImage);
                }
                context.Workers.Add(worker);
                context.SaveChanges();
                TempData["message"] = string.Format("Работник \"{0}\" был добавлен", worker.Name);
                return RedirectToAction("GetWorkersList", "Admin");
            }
        }

        [AllowAnonymous]
        public async Task<FileContentResult> GetBigImage(int workerId)
        {
            Worker worker = await Mediator.Send(new FindWorkerByIdQuery { Id = workerId });

            if (worker != null && worker.BigImage?.ImageData != null)
            {
                return File(worker.BigImage.ImageData, worker.BigImage.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        [AllowAnonymous]
        public async Task<FileContentResult> GetImage(int workerId)
        {
            Worker worker = await Mediator.Send(new FindWorkerByIdQuery { Id = workerId });

            if (worker != null && worker.SmallImage?.ImageData != null)
            {
                return File(worker.SmallImage.ImageData, worker.SmallImage.ImageMimeType);
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
            Worker worker = _citySpeaksContext.Workers
                .Include(x => x.BigImage)
                .Include(x => x.SmallImage)
                .First(x => x.Id == id);
            return View(worker);
        }

        // GET: Workers/Delete/5
        public ActionResult Delete(int id)
        {
            var worker = _citySpeaksContext.Workers.Where(c => c.Id == id).FirstOrDefault();
            _citySpeaksContext.Entry(worker).State = EntityState.Deleted;
            _citySpeaksContext.SaveChanges();
            TempData["message"] = string.Format("Данные о работнике {0} были удалены", worker.Name);
            return RedirectToAction("GetWorkersList", "Admin");
        }

        // POST: Workers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
