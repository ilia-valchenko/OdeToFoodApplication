using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core.Entities;
using OdeToFood.DataAccess.Repositories.Interfaces;

namespace OdeToFoodApplication
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantRepository repository;

        // We can bind our TempData to some property.
        [TempData]
        public string SuccessfullySavedMessage { get; set; }

        public Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = repository.Get(restaurantId);

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}