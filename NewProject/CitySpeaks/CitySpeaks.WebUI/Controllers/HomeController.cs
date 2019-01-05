using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CitySpeaks.WebUI.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using CitySpeaks.Infrastructure;

namespace CitySpeaks.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        CitySpeaksContext _citySpeaksContext;

        public HomeController(CitySpeaksContext citySpeaksContext)
        {
            _citySpeaksContext = citySpeaksContext;
        }
        public async Task<IActionResult> Index()
        {
            await Mediator.Send(new Application.News.Commands.AddNewsCommand() { Name = "" });
            return View(new LoginViewModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel loginViewModel)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginViewModel.UserName),
                new Claim(ClaimTypes.Role, "Administrator"),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties());

            return RedirectToAction("Privacy", "Home");
        }
    }
}
