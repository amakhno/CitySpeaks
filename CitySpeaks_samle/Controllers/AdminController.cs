using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitySpeaks_samle.Models;
using CitySpeaks_samle.Models.Admin;

namespace CitySpeaks_samle.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public static int pageSize = 10;

        // GET: Admin
        public ActionResult Index()
        {
            return RedirectToAction("Edit", "MainPage", new { id = 1 });
        }

        public ViewResult GetNewsList(int page = 1)
        {
            AdminNewsList model = new AdminNewsList
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

        public ViewResult GetWorkersList()
        {
            List<Workers> workers = (new ApplicationDbContext()).Workers.ToList();
            return View(workers);
        }

        public ViewResult GetReviewList()
        {
            List<Review> workers = (new ApplicationDbContext()).Review.ToList();
            return View(workers);
        }

        public ViewResult GetProgramsList(int page = 1)
        {
            AdminProgramsList model = new AdminProgramsList
            {
                Programs = (new ApplicationDbContext()).Programs
                    .OrderByDescending(news => news.ProgramId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = (new ApplicationDbContext()).Programs.Count()
                }
            };
            return View(model);
        }

        public ViewResult GetCategoryList(int page = 1)
        {
            AdminCategoryList model = new AdminCategoryList
            {
                Category = (new ApplicationDbContext()).Categories
                    .OrderByDescending(news => news.CategoryId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = (new ApplicationDbContext()).Categories.Count()
                }
            };
            return View(model);
        }

        public ViewResult GetCustomPageList(int page = 1)
        {
            AdminCustomPageList model = new AdminCustomPageList
            {
                CustomPage = (new ApplicationDbContext()).CustomPage
                    .OrderByDescending(news => news.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = (new ApplicationDbContext()).CustomPage.Count()
                }
            };
            return View(model);
        }
    }
}
