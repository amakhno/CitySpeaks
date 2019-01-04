using System.Linq;
using System.Threading.Tasks;
using CitySpeaks.Domain.Models;
using CitySpeaks.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CitySpeaks_samle.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController()
        {
        }

        //
        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.UserName };
                return RedirectToAction("Index", "Home");

            }

            // Появление этого сообщения означает наличие ошибки; повторное отображение формы
            return View(model);
        }        
    }
}