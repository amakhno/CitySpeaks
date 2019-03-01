using CitySpeaks.Domain.Models;
using CitySpeaks.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitySpeaks.WebUI.ViewComponents
{
    public class ListOfWorkers : ViewComponent
    {
        private readonly CitySpeaksContext _citySpeaksContext;

        public ListOfWorkers(CitySpeaksContext citySpeaksContext)
        {
            _citySpeaksContext = citySpeaksContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Worker> result = await _citySpeaksContext.Workers.ToListAsync();
            return View(result);
        }
    }
}
