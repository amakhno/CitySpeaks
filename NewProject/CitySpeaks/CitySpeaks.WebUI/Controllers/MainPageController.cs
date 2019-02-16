using CitySpeaks.Domain.Models;
using CitySpeaks.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CitySpeaks.WebUI.Controllers
{
    [Authorize]
    public class MainPageController : BaseController
    {
        private readonly CitySpeaksContext _citySpeaksContext;

        public MainPageController(CitySpeaksContext citySpeaksContext)
        {
            _citySpeaksContext = citySpeaksContext;
        }

        [HttpPost]
        public async Task<ActionResult> Edit(MainPage mainPage, IFormFile image1, IFormFile image2)
        {
            if ((mainPage.Id != 0) && (_citySpeaksContext.MainPages.Where(c => c.Id == 1).FirstOrDefault() != null))
            {
                var UpdateMainPage = _citySpeaksContext.MainPages.Where(c => c.Id == 1).FirstOrDefault();
                if ((image1 == null && UpdateMainPage.MainImageData == null) || (image2 == null && UpdateMainPage.LogolImageData == null) || !ModelState.IsValid)
                {
                    TempData["message"] = "Не получены изображения";
                    return View(mainPage);
                }
                if (image1 != null)
                {
                    UpdateMainPage.MainImageMimeType = image1.ContentType;
                    if (image1 is FormFile image1asFormFile)
                    {
                        UpdateMainPage.MainImageData = new byte[image1asFormFile.Length];
                        using (var stream = image1asFormFile.OpenReadStream())
                        {
                            stream.Read(UpdateMainPage.MainImageData, 0, (int)image1asFormFile.Length);
                        }
                    }                       
                }
                if (image2 != null)
                {
                    UpdateMainPage.LogoImageMimeType = image2.ContentType;
                    using (var stream = image2.OpenReadStream())
                    {
                        stream.Read(UpdateMainPage.LogolImageData, 0, 0);
                    }
                }
                UpdateMainPage.Title = mainPage.Title;
                UpdateMainPage.Subtitle = mainPage.Subtitle;
                UpdateMainPage.Description = mainPage.Description;
                _citySpeaksContext.Entry(UpdateMainPage).State = EntityState.Modified;
                _citySpeaksContext.SaveChanges();
                TempData["message"] = string.Format("Изменения были сохранены");
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                if ((image1 == null) || (image2 == null) || !ModelState.IsValid)
                {
                    TempData["message"] = "Не получены изображения";
                    return View(mainPage);
                }

                mainPage.MainImageMimeType = image1.ContentType;
                using (var stream = image1.OpenReadStream())
                {
                    stream.Read(mainPage.MainImageData, 0, 0);
                }


                mainPage.LogoImageMimeType = image2.ContentType;
                using (var stream = image2.OpenReadStream())
                {
                    stream.Read(mainPage.LogolImageData, 0, 0);
                }

                _citySpeaksContext.MainPages.Add(mainPage);
                _citySpeaksContext.SaveChanges();
                TempData["message"] = string.Format("Оформление было добавлено");
                return RedirectToAction("Index", "Admin");
            }
        }

        [AllowAnonymous]
        public FileContentResult GetMainImage(int newsId)
        {
            MainPage mainPage = _citySpeaksContext.MainPages
                .FirstOrDefault(g => g.Id == newsId);

            if (mainPage != null && mainPage.MainImageData != null)
            {
                return File(mainPage.MainImageData, mainPage.MainImageMimeType);
            }
            else
            {
                return null;
            }
        }

        [AllowAnonymous]
        public FileContentResult GetLogoImage(int newsId)
        {
            MainPage mainPage = _citySpeaksContext.MainPages
                .FirstOrDefault(g => g.Id == newsId);

            if (mainPage != null && mainPage.LogolImageData != null)
            {
                return File(mainPage.LogolImageData, mainPage.LogoImageMimeType);
            }
            else
            {
                return null;
            }
        }


        // GET: News/Edit/5
        public ActionResult Edit(int id = 1)
        {
            if (id == 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            var mainPage = _citySpeaksContext.MainPages;
            if (mainPage.Where(x => x.Id == id).Count() == 0)
            {
                return View(new MainPage());
            }
            return View(mainPage.FirstOrDefault());
        }
    }
}