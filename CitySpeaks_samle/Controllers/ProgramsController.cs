using CitySpeaks_samle.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CitySpeaks_samle.Controllers
{
    public class ProgramsController : Controller
    {
        // GET: Programs
        public ActionResult Index()
        {
            return View();
        }

        // GET: Programs/Details/5
        public ActionResult Show(int id = 1)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            Programs model = context.Programs.First(x => x.ProgramId == id);
            context.Dispose();
            return View(model);
        }

        // GET: Programs/Create
        public ActionResult Create()
        {
            return View("Edit", new Programs()); 
        }

        // POST: Programs/Create
        [HttpPost]
        public ActionResult Edit(Programs program, HttpPostedFileBase image1, HttpPostedFileBase image2)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            if (program.ProgramId!=0)
            {                
                context = new ApplicationDbContext();
                var UpdatePrograms = context.Programs.Where(c => c.ProgramId == program.ProgramId).FirstOrDefault();
                if ((image1 == null && UpdatePrograms.SmallImageData == null) || (image2 == null && UpdatePrograms.BigImageData == null) || !ModelState.IsValid)
                {
                    TempData["message"] = "Не получены изображения";
                    return View(UpdatePrograms);
                }
                UpdatePrograms.CategoryId = Programs.GetCategoryByName(program.Category.Name);
                if (image1 != null)
                {
                    UpdatePrograms.SmallImageMimeType = image1.ContentType;
                    UpdatePrograms.SmallImageData = new byte[image1.ContentLength];
                    image1.InputStream.Read(UpdatePrograms.SmallImageData, 0, image1.ContentLength);
                }
                if (image2 != null)
                {
                    UpdatePrograms.BigImageMimeType = image2.ContentType;
                    UpdatePrograms.BigImageData = new byte[image2.ContentLength];
                    image2.InputStream.Read(UpdatePrograms.BigImageData, 0, image2.ContentLength);
                }
                UpdatePrograms.Name = program.Name;
                UpdatePrograms.ShortDescription = program.ShortDescription;
                UpdatePrograms.FullDescription = program.FullDescription;
                context.Entry(UpdatePrograms).State = EntityState.Modified;
                context.SaveChanges();
                TempData["message"] = string.Format("Изменения в программе \"{0}\" были сохранены", program.Name);
                return RedirectToAction("GetProgramsList", "Admin");
            }
            else
            {
                if (image1 == null || image2 == null || !ModelState.IsValid)
                {
                    TempData["message"] = "Не получены изображения";
                    return View(program);
                }
                var tmp = Programs.GetCategoryByName(program.Category.Name);
                program.Category = null;
                program.CategoryId = tmp;
                if (image1 != null)
                {
                    program.SmallImageMimeType = image1.ContentType;
                    program.SmallImageData = new byte[image1.ContentLength];
                    image1.InputStream.Read(program.SmallImageData, 0, image1.ContentLength);
                }
                if (image2 != null)
                {
                    program.BigImageMimeType = image2.ContentType;
                    program.BigImageData = new byte[image2.ContentLength];
                    image2.InputStream.Read(program.BigImageData, 0, image2.ContentLength);
                }
                //repository.SaveGame(game);
                context.Entry(program).State = EntityState.Added;
                context.SaveChanges();
                TempData["message"] = string.Format("Программа \"{0}\" была создана", program.Name);
                return RedirectToAction("GetProgramsList", "Admin");
            }     
        }

        public FileContentResult GetBigImage(int programId)
        {
            ApplicationDbContext cnt = new ApplicationDbContext();
            Programs program = cnt.Programs
                .FirstOrDefault(g => g.ProgramId == programId);

            if (program != null && program.BigImageData != null)
            {
                return File(program.BigImageData, program.BigImageMimeType);
            }
            else
            {
                return null;
            }
            }

        public FileContentResult GetSmallImage(int programId)
        {
            ApplicationDbContext cnt = new ApplicationDbContext();
            Programs program = cnt.Programs
                .FirstOrDefault(g => g.ProgramId == programId);

            if (program != null && program.SmallImageData != null)
            {
                return File(program.SmallImageData, program.SmallImageMimeType);
            }
            else
            {
                return null;
            }
        }


        // GET: Programs/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if(id == 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            Programs Programs = (new ApplicationDbContext()).Programs.First(x => x.ProgramId == id);
            return View(Programs);
        }

        // GET: Programs/Delete/5
        public ActionResult Delete(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var deletePrograms = context.Programs.Where(c => c.ProgramId == id).FirstOrDefault();
            context.Entry(deletePrograms).State = EntityState.Deleted;
            context.SaveChanges();
            TempData["message"] = string.Format("Программа {0} была удалена", deletePrograms.Name);
            return RedirectToAction("GetProgramsList", "Admin");
        }

        // POST: Programs/Delete/5
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

        public ActionResult GetGridPrograms()
        {
            List<Programs> model;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                model = context.Programs.Take((context.Programs.Count() >= 6) ? 6 : context.Programs.Count()).ToList();
            }
            return View(model);
        }
    }
}
