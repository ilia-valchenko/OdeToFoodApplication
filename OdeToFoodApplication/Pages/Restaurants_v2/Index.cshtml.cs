using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core.Entities;
using OdeToFood.DataAccess;

namespace OdeToFoodApplication
{
    public class IndexModel : PageModel
    {
        private readonly OdeToFood.DataAccess.OdeToFoodDbContext _context;

        public IndexModel(OdeToFood.DataAccess.OdeToFoodDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
