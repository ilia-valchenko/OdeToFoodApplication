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

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<Cuisine>();

            if (restaurantId.HasValue)
            {
                Restaurant = repository.Get(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }

            if (Restaurant == null)
            {
                return RedirectToPage("NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            // ModelState.IsValid
            // ModelState["Location"]
            // ModelState["Location"].Errors
            // ModelState["Location"].AttemptedValue

            if (!ModelState.IsValid)
            {
                // We need to fill Cuisines again because our ASP .NET application is stateless.
                Cuisines = htmlHelper.GetEnumSelectList<Cuisine>();

                return Page();
            }

            if (Restaurant.Id > 0)
            {
                // It works fine bacause of model binding.
                repository.Update(Restaurant);
            }
            else
            {
                repository.Create(Restaurant);
            }

            // Any pages of the application can look into TempData and use it's values.
            // Does TempData exist per request?
            TempData["SuccessfullySavedMessage"] = "Restaurant saved!";

            repository.Commit();

            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}