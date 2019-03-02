using CitySpeaks.Application.Users.Commands;
using CitySpeaks.Infrastructure.Interfaces.Dto.User;
using CitySpeaks.Persistence;
using CitySpeaks.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CitySpeaks.WebUI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly CitySpeaksContext _citySpeaksContext;

        public AccountController(CitySpeaksContext citySpeaksContext)
        {
            _citySpeaksContext = citySpeaksContext;
        }

        [Route("/register")]
        public ActionResult Register()
        {
            return View();
        }

        [Route("/login")]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [Route("/login")]
        public async Task<ActionResult> Login(LoginViewModel loginViewModel, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await Mediator.Send(new LoginUserCommand { UserName = loginViewModel.Email,
                    Password = loginViewModel.Password });
                if (result == null)
                {
                    ModelState.AddModelError("Password", "Cannot find user with this credentials");
                    return View(loginViewModel);
                }
                await LogInWithCookies(result.UserName, result.RoleName);
                return Redirect(ReturnUrl);
            }
            return View(loginViewModel);
        }

        [Route("/logout")]
        public async Task<ActionResult> Logout()
        {
            await LogOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("/register")]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                CreateUserCommand createUserCommand = new CreateUserCommand()
                {
                    RegisterDto = new LoginDto(model.Email, model.Password)
                };
                var userWithRoleNames = await Mediator.Send(createUserCommand);
                await LogInWithCookies(userWithRoleNames.UserName, userWithRoleNames.RoleName);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        private async Task LogInWithCookies(string userName, string roleName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, userName),
                new Claim(ClaimTypes.Role, roleName),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties());
        }

        private async Task LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}