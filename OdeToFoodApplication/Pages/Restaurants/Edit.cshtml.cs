using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core.Entities;
using OdeToFood.Core.Enums;
using OdeToFood.DataAccess.Repositories.Interfaces;

namespace OdeToFoodApplication
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantRepository repository;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantRepository repository, IHtmlHelper htmlHelper)
        {
            this.repository = repository;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = repository.Get(restaurantId);
            Cuisines = htmlHelper.GetEnumSelectList<Cuisine>();

            if (Restaurant == null)
            {
                return RedirectToPage("NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            // We need to fill Cuisines again because our ASP .NET application is stateless.
            Cuisines = htmlHelper.GetEnumSelectList<Cuisine>();

            // It works fine bacause of model binding.
            repository.Update(Restaurant);
            repository.Commit();

            return Page();
        }
    }
}