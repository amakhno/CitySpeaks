using CitySpeaks.Application.ProgramCategories.Queries;
using CitySpeaks.Domain.Models;
using CitySpeaks.Persistence;
using CitySpeaks.WebUI.Models.Helpers;
using CitySpeaks.WebUI.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitySpeaks.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        static public int pageSize = 6;
        private readonly CitySpeaksContext _citySpeaksContext;

        public HomeController(CitySpeaksContext citySpeaksContext)
        {
            _citySpeaksContext = citySpeaksContext;
        }

        public ActionResult Index()
        {
            MainPage model;
            if (_citySpeaksContext.MainPages.Count() == 0)
            {
                model = new MainPage();
            }
            else
            {
                model = _citySpeaksContext.MainPages.First();
            }
            return View(model);
        }

        //Отображение последней новости
        public ActionResult LastNews()
        {
            if (_citySpeaksContext.News.Count() < 2)
            {
                return PartialView(null);
            }
            return PartialView(_citySpeaksContext.News.OrderByDescending(x => x.Date).Take(2).ToList());
        }

        //Отображение списка категорий
        public async Task<ActionResult> ListOfCategory()
        {
            List<string> result = new List<string>();
            GetListOfCategoriesQuery getListOfCategoriesQuery = new GetListOfCategoriesQuery();
            int FindId = await Mediator.Send(new GetCategoryByNameQuery("Без категории"));
            foreach (ProgramCategory category in _citySpeaksContext.ProgramCategories)
            {
                if (category.CategoryId != FindId)
                    result.Add(category.Name);
            }
            return PartialView(result.ToArray());
        }

        //Отображение программ категории "Категории"
        public async Task<ActionResult> ListOfUnCategory()
        {
            int FindId = await Mediator.Send(new GetCategoryByNameQuery("Без категории"));
            var result = new List<Domain.Models.Program>();
            var db = _citySpeaksContext.Programs.Where(x => x.CategoryId == FindId);
            foreach (var prog in db)
            {
                result.Add(prog);
            }
            return PartialView(result);
        }

        public ActionResult ListOfWorkers()
        {
            List<Worker> result = _citySpeaksContext.Workers.ToList();
            return PartialView(result);
        }

        public ViewResult GetNewsList(int page = 1)
        {
            UserNewsList model = new UserNewsList
            {
                News = (_citySpeaksContext).News
                    .OrderByDescending(news => news.Date)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = (_citySpeaksContext).News.Count()
                }
            };
            return View(model);
        }

        public ViewResult GetReviewList(int page = 1)
        {
            var Review = (_citySpeaksContext).Reviews.ToList();
            Review.Reverse();
            return View(Review);
        }

        public ViewResult GetProgramsList(int page = 1, string category = "")
        {
            UserProgramsList model = new UserProgramsList
            {
                Programs = (_citySpeaksContext).Programs.Where(x => (x.Category.Name == category) || (category == ""))
                    .OrderByDescending(news => news.ProgramId)
                    /*.Skip((page - 1) * pageSize)
                    .Take(pageSize)*/,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = (_citySpeaksContext).Programs.Where(x => (x.Category.Name == category) || (category == "")).Count()
                }
            };
            return View(model);
        }
    }
}