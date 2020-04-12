using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core.Entities;
using OdeToFood.Core.Enums;
using OdeToFood.Core.Exceptions;
using OdeToFood.DataAccess.Repositories.Interfaces;

namespace OdeToFood.DataAccess.Repositories
{
    public sealed class InMemoryRestaurantRepository : IRestaurantRepository
    {
        private readonly IEnumerable<Restaurant> restaurants;

        public InMemoryRestaurantRepository()
        {
            restaurants = new[]
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "Vasilky",
                    Cuisine = Cuisine.Belarusian,
                    Location = "Belarus, Minsk, Bobryiskaya street 18"
                },
                new Restaurant
                {
                    Id = 2,
                    Name = "Taco Boss",
                    Cuisine = Cuisine.Mexican,
                    Location = "Mexico, Tivalli, Main street 2"
                },
                new Restaurant
                {
                    Id = 3,
                    Name = "Don Vincenso",
                    Cuisine = Cuisine.Italian,
                    Location = "Italy, Rome, Leonardo street 87"
                },
                new Restaurant
                {
                    Id = 4,
                    Name = "Sweet cartel",
                    Cuisine = Cuisine.Mexican,
                    Location = "Mexico, La Paz, Mamboo street 63"
                },
                new Restaurant
                {
                    Id = 5,
                    Name = "Gustave",
                    Cuisine = Cuisine.Italian,
                    Location = "Italy, Florence, Petrero street 17"
                }
            };
        }

        public IEnumerable<Restaurant> Get()
        {
            return restaurants;
        }

        public IEnumerable<Restaurant> Search(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The name of a restaurant is null or whitespace.");
            }

            return restaurants
                .Where(r => r.Name.Contains(name))
                .OrderBy(r => r.Name);
        }

        public Restaurant Get(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            if (updatedRestaurant == null)
            {
                throw new ArgumentNullException(nameof(updatedRestaurant));
            }

            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);

            if (restaurant == null)
            {
                throw new ResourceNotFoundException("The restaurant with provided id wasn't found.");
            }

            restaurant.Name = updatedRestaurant.Name;
            restaurant.Location = updatedRestaurant.Location;
            restaurant.Cuisine = updatedRestaurant.Cuisine;

            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }
    }
}