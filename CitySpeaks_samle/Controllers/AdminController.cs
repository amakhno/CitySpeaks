using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CitySpeaks_samle.Models;
using CitySpeaks_samle.Models.Admin;

namespace CitySpeaks_samle.Controllers
{
    public class AdminController : Controller
    {
        public static int pageSize = 10;

        // GET: Admin
        public ActionResult Index()
        {
            return View();
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
                Category = (new ApplicationDbContext()).Categories.Where(x=>x.CategoryId != 1)
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
    }
}
