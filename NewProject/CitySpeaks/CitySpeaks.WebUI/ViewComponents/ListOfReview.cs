using CitySpeaks.Domain.Models;
using CitySpeaks.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitySpeaks.WebUI.ViewComponents
{
    public class ListOfReview : ViewComponent
    {
        private readonly CitySpeaksContext _citySpeaksContext;

        public ListOfReview(CitySpeaksContext citySpeaksContext)
        {
            _citySpeaksContext = citySpeaksContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Review> result;
            int count = _citySpeaksContext.Reviews.Count();
            if (count > 2)
            {
                result = await _citySpeaksContext.Reviews.OrderByDescending(x => x.Id).Take(5).ToListAsync();
            }
            else
            {
                result = await _citySpeaksContext.Reviews.ToListAsync();
            }
            return View(result);
        }
    }
}
