using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core.Entities;
using OdeToFood.DataAccess.Repositories.Interfaces;

namespace OdeToFoodApplication
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantRepository repository;

        public Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantRepository repository)
        {
            this.repository = repository;
        }

        public void OnGet(int restaurantId)
        {
            Restaurant = repository.Get(restaurantId);
        }
    }
}