using CitySpeaks_samle.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitySpeaks_samle.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Create()
        {
            return View("Edit", new ProgramCategories());
        }

        // GET: Category
        [HttpPost]
        public ActionResult Create(ProgramCategories category)
        {
            return View("Edit", new ProgramCategories());
        }

        [HttpPost]
        public ActionResult Edit(ProgramCategories category)
        {

            ApplicationDbContext context = new ApplicationDbContext();
            if (category.CategoryId != 0)
            {
                context = new ApplicationDbContext();
                var UpdatePrograms = context.Categories.Where(c => c.CategoryId == category.CategoryId).FirstOrDefault();
                if (ModelState.IsValid)
                {
                    return View(UpdatePrograms);
                }
                UpdatePrograms.Name = category.Name;                
                context.Entry(UpdatePrograms).State = EntityState.Modified;
                context.SaveChanges();
                TempData["message"] = string.Format("Изменения в категории \"{0}\" были сохранены", category.Name);
                return RedirectToAction("GetCategoryList", "Admin");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(category);
                }
                context.Entry(category).State = EntityState.Added;
                context.SaveChanges();
                TempData["message"] = string.Format("Категория \"{0}\" была создана", category.Name);
                return RedirectToAction("GetCategoryList", "Admin");
            }
        }

        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            ProgramCategories category = (new ApplicationDbContext()).Categories.First(x => x.CategoryId == id);
            return View(category);
        }

        public ActionResult Delete(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            foreach(Programs programs in context.Programs.Where(x=>x.CategoryId == id))
            {
                programs.CategoryId = 1;
                context.Entry(programs).State = EntityState.Modified;
            }
            context.Entry(context.Categories.First(x => x.CategoryId == id)).State = EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("GetCategoryList", "Admin");
        }
    }
}