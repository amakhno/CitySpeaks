using CitySpeaks_samle.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CitySpeaks_samle.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        // GET: News/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View("Edit", new News());
        }

        // GET: News/Create
        public ActionResult Show(int id)
        {
            News news = (new ApplicationDbContext()).News.First(x => x.NewsId == id);
            return View(news);
        }

        // POST: News/Create
        [HttpPost]
        public ActionResult Edit(News news, HttpPostedFileBase image1, HttpPostedFileBase image2)
        {

            ApplicationDbContext context = new ApplicationDbContext();
            if (news.NewsId!=0)
            {                
                var UpdateNews = context.News.Where(c => c.NewsId == news.NewsId).FirstOrDefault();
                if ((image1 == null && UpdateNews.SmallImageData == null) || (image2 == null && UpdateNews.BigImageData == null) || !ModelState.IsValid)
                {
                    TempData["message"] = "Не получены изображения";
                    return View(news);
                }
                if (image1 != null)
                {
                    UpdateNews.SmallImageMimeType = image1.ContentType;
                    UpdateNews.SmallImageData = new byte[image1.ContentLength];
                    image1.InputStream.Read(UpdateNews.SmallImageData, 0, image1.ContentLength);
                }
                if (image2 != null)
                {
                    UpdateNews.BigImageMimeType = image2.ContentType;
                    UpdateNews.BigImageData = new byte[image2.ContentLength];
                    image2.InputStream.Read(UpdateNews.BigImageData, 0, image2.ContentLength);
                }
                UpdateNews.Name = news.Name;
                UpdateNews.ShortDescription = news.ShortDescription;
                UpdateNews.FullDescription = news.FullDescription;
                context.Entry(UpdateNews).State = EntityState.Modified;
                context.SaveChanges();
                TempData["message"] = string.Format("Изменения в новости \"{0}\" были сохранены", news.Name);
                return RedirectToAction("GetNewsList", "Admin");
            }
            else
            {
                news.Date = DateTime.Now;
                if (image1 != null)
                {
                    news.SmallImageMimeType = image1.ContentType;
                    news.SmallImageData = new byte[image1.ContentLength];
                    image1.InputStream.Read(news.SmallImageData, 0, image1.ContentLength);
                }
                if (image2 != null)
                {
                    news.BigImageMimeType = image2.ContentType;
                    news.BigImageData = new byte[image2.ContentLength];
                    image2.InputStream.Read(news.BigImageData, 0, image2.ContentLength);
                }
                ApplicationDbContext cnt = new ApplicationDbContext();
                cnt.News.Add(news);
                cnt.SaveChanges();
                TempData["message"] = string.Format("Новость \"{0}\" была создана", news.Name);
                return RedirectToAction("GetNewsList", "Admin");
            }
        }

        public FileContentResult GetBigImage(int newsId)
        {
            ApplicationDbContext cnt = new ApplicationDbContext();
            News game = cnt.News
                .FirstOrDefault(g => g.NewsId == newsId);

            if (game != null && game.BigImageData != null)
            {
                return File(game.BigImageData, game.BigImageMimeType);
            }
            else
            {
                return null;
            }
            }

        public FileContentResult GetSmallImage(int newsId)
        {
            ApplicationDbContext cnt = new ApplicationDbContext();
            News game = cnt.News
                .FirstOrDefault(g => g.NewsId == newsId);

            if (game != null && game.SmallImageData != null)
            {
                return File(game.SmallImageData, game.SmallImageMimeType);
            }
            else
            {
                return null;
            }
        }


        // GET: News/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if(id == 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            News news = (new ApplicationDbContext()).News.First(x => x.NewsId == id);
            return View(news);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var deleteNews = context.News.Where(c => c.NewsId == id).FirstOrDefault();
            context.Entry(deleteNews).State = EntityState.Deleted;
            context.SaveChanges();
            TempData["message"] = string.Format("Новость {0} была удалена", deleteNews.Name);
            return RedirectToAction("GetNewsList", "Admin");
        }

        // POST: News/Delete/5
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

        public ActionResult LastNews()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            return PartialView(context.News.OrderByDescending(x => x.Date).FirstOrDefault());
        }
    }
}
