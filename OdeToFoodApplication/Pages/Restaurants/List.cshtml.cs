using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core.Entities;
using OdeToFood.DataAccess.Repositories.Interfaces;

namespace OdeToFoodApplication
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IRestaurantRepository repository;

        // By defaults BindProperty attributes for only HTTP Post methods.
        // We can change that behavior.
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantRepository restaurantRepository)
        {
            this.configuration = configuration;
            this.repository = restaurantRepository;
        }

        public void OnGet()
        {
            this.Restaurants = string.IsNullOrWhiteSpace(this.SearchTerm)
                ? repository.Get()
                : repository.Search(this.SearchTerm);
        }
    }
}