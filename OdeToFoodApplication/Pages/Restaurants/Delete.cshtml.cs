using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core.Entities;
using OdeToFood.DataAccess.Repositories.Interfaces;

namespace OdeToFoodApplication
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantRepository repository;

        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantRepository repository)
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

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = repository.Delete(restaurantId);

            repository.Commit();

            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{restaurant.Name} was successfully deleted.";

            return RedirectToPage("./List");
        }
    }
}