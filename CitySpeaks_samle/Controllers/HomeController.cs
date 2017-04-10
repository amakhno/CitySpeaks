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
            MainPage model;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (context.MainPage.Count() == 0)
                {
                    model = new MainPage();
                }
                else
                {
                    model = context.MainPage.First();
                }
            }
            return View(model);
        }

        //Отображение последней новости
        public ActionResult LastNews()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            if (context.News.Count() < 2)
            {
                return PartialView(null);
            }
            return PartialView(context.News.OrderByDescending(x => x.Date).Take(2).ToList());
        }

        //Отображение списка категорий
        public ActionResult ListOfCategory()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<string> result = new List<string>();
            int FindId = Programs.GetCategoryByName("Без категории");
            foreach (ProgramCategories category in context.Categories)
            {
                if (category.CategoryId != FindId)
                    result.Add(category.Name);
            }
            return PartialView(result.ToArray());
        }

        //Отображение программ категории "Категории"
        public ActionResult ListOfUnCategory()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            int FindId = Programs.GetCategoryByName("Без категории");
            List<Programs> res = new List<Programs>();
            var db = context.Programs.Where(x=>x.CategoryId == FindId);
            foreach (var prog in db)
            {
                res.Add(prog);
            }
            return PartialView(res);
        }

        public ActionResult ListOfWorkers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<Workers> result = context.Workers.ToList();
            return PartialView(result);
        }

        public ActionResult ListOfReview()
        {
            List<Review> result;
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                int count = context.Review.Count();
                if (count > 2)
                {
                    result = context.Review.OrderByDescending(x=>x.Id).Take(5).ToList();
                }
                else
                {
                    result = context.Review.ToList();
                }                
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

        public ViewResult GetReviewList(int page = 1)
        {
            var Review = (new ApplicationDbContext()).Review.ToList();
            Review.Reverse();
            return View(Review);
        }

        public ViewResult GetProgramsList(int page = 1, string category = "")
        {
            UserProgramsList model = new UserProgramsList
            {
                Programs = (new ApplicationDbContext()).Programs.Where(x => (x.Category.Name == category) || (category == ""))
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