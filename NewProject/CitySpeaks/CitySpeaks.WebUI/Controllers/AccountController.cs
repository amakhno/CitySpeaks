using CitySpeaks.Domain.Models;
using CitySpeaks.Infrastructure;
using CitySpeaks.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;

namespace CitySpeaks_samle.Controllers
{
    public class AccountController : Controller
    {
        private readonly CitySpeaksContext _citySpeaksContext;

        public AccountController(CitySpeaksContext citySpeaksContext)
        {
            _citySpeaksContext = citySpeaksContext;
        }

        public ActionResult Register()
        {
            return View();
        }

        [Route("/login")]
        public ActionResult Login()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope(
                    TransactionScopeOption.Required,
                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }, TransactionScopeAsyncFlowOption.Enabled))
                {
                    var role = await _citySpeaksContext.Roles.SingleOrDefaultAsync(x => x.Name == "User");
                    if (role == null)
                    {
                        role = (await _citySpeaksContext.Roles.AddAsync(new Role { Name = "User" })).Entity;
                        _citySpeaksContext.SaveChanges();
                    }
                    scope.Complete();
                    var user = new User { UserName = model.UserName, Password = model.Password, RoleId = role.Id };                    
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}