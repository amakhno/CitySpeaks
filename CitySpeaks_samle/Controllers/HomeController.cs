using CitySpeaks_samle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitySpeaks_samle.Controllers
{
    public class HomeController : Controller
    {
        static public int pageSize = 6;

        public ActionResult Index()
        {
            return View();
        }

        //Отображение последней новости
        public ActionResult LastNews()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            if (context.News.Count() == 0)
            {
                return PartialView(null);
            }
            return PartialView(context.News.OrderByDescending(x => x.Date).FirstOrDefault());
        }

        //Отображение списка категорий
        public ActionResult ListOfCategory()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<string> result = new List<string>();
            foreach(ProgramCategories category in context.Categories)
            {
                if(category.CategoryId != 1)
                result.Add(category.Name);
            }
            return PartialView(result.ToArray());
        }

        //Отображение программ категории "Категории"
        public ActionResult ListOfUnCategory()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<Programs> result = new List<Programs>();
            foreach (Programs prog in context.Programs)
            {
                if (prog.CategoryId == 1)
                    result.Add(prog);
            }
            return PartialView(result);
        }

        public ViewResult GetNewsList(int page = 1)
        {
            UserNewsList model = new UserNewsList
            {
                News = (new ApplicationDbContext()).News
                    .OrderByDescending(news => news.Date)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = (new ApplicationDbContext()).News.Count()
                }
            };
            return View(model);
        }

        public ViewResult GetProgramsList(int page = 1, string category = "")
        {
            UserProgramsList model = new UserProgramsList
            {
                Programs = (new ApplicationDbContext()).Programs.Where(x=>(x.Category.Name == category) || (category == ""))
                    .OrderByDescending(news => news.ProgramId)
                    /*.Skip((page - 1) * pageSize)
                    .Take(pageSize)*/,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = (new ApplicationDbContext()).Programs.Where(x => (x.Category.Name == category) || (category == "")).Count()
                }
            };
            return View(model);
        }
    }
}