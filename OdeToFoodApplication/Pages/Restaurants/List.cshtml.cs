using System.Collections.Generic;
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

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantRepository restaurantRepository)
        {
            this.configuration = configuration;
            this.repository = restaurantRepository;
        }

        //public void OnGet()
        //{
        //    var defaultMessage = (string)configuration.GetValue(typeof(string), "DefaultMessage");

        //    Message = string.IsNullOrWhiteSpace(defaultMessage)
        //        ? "Hello World!"
        //        : defaultMessage;

        //    this.Restaurants = repository.Get();
        //}

        public void OnGet(string searchTerm)
        {
            this.Restaurants = string.IsNullOrWhiteSpace(searchTerm)
                ? repository.Get()
                : repository.Search(searchTerm);
        }
    }
}