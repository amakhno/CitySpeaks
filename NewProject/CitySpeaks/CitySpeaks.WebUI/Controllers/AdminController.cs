using CitySpeaks.Domain.Models;
using CitySpeaks.Persistence;
using CitySpeaks.WebUI.Controllers;
using CitySpeaks.WebUI.Models.Admin;
using CitySpeaks.WebUI.Models.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CitySpeaks.WebUI.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        public static int pageSize = 10;

        private readonly CitySpeaksContext _citySpeaksContext;

        public AdminController(CitySpeaksContext citySpeaksContext)
        {
            _citySpeaksContext = citySpeaksContext;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return RedirectToAction("Edit", "MainPage", new { id = 1 });
        }

        public ViewResult GetNewsList(int page = 1)
        {
            AdminNewsList model = new AdminNewsList
            {
                News = _citySpeaksContext.News
                    .OrderByDescending(news => news.Date)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _citySpeaksContext.News.Count()
                }
            };
            return View(model);
        }

        public ViewResult GetWorkersList()
        {
            List<Worker> workers = _citySpeaksContext.Workers.ToList();
            return View(workers);
        }

        public ViewResult GetReviewList()
        {
            List<Review> workers = _citySpeaksContext.Reviews.ToList();
            return View(workers);
        }

        public ViewResult GetProgramsList(int page = 1)
        {
            AdminProgramsList model = new AdminProgramsList
            {
                Programs = _citySpeaksContext.Programs
                    .OrderByDescending(news => news.ProgramId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _citySpeaksContext.Programs.Count()
                }
            };
            return View(model);
        }

        public ViewResult GetCategoryList(int page = 1)
        {
            AdminCategoryList model = new AdminCategoryList
            {
                Category = _citySpeaksContext.ProgramCategories
                    .OrderByDescending(news => news.CategoryId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _citySpeaksContext.ProgramCategories.Count()
                }
            };
            return View(model);
        }

        public ViewResult GetCustomPageList(int page = 1)
        {
            AdminCustomPageList model = new AdminCustomPageList
            {
                CustomPage = _citySpeaksContext.CustomPages
                    .OrderByDescending(news => news.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _citySpeaksContext.CustomPages.Count()
                }
            };
            return View(model);
        }
    }
}
