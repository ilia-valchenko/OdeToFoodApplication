using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core.Entities;
using OdeToFood.DataAccess.Repositories.Interfaces;

namespace OdeToFood.DataAccess.Repositories
{
    public sealed class SqlRestaurantRepository : IRestaurantRepository
    {
        private readonly OdeToFoodDbContext context;

        public SqlRestaurantRepository(OdeToFoodDbContext context)
        {
            this.context = context;
        }

        public int Commit()
        {
            // TODO: Use async version.
            return context.SaveChanges();
        }

        public Restaurant Create(Restaurant newRestaurant)
        {
            // TODO: Use async version.
            context.Add(newRestaurant);

            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = Get(id);

            if (restaurant != null)
            {
                context.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public IEnumerable<Restaurant> Get()
        {
            throw new NotImplementedException();
        }

        public Restaurant Get(int id)
        {
            return context.Restaurants.Single(r => r.Id == id);
        }

        public IEnumerable<Restaurant> Search(string name)
        {
            return context.Restaurants.Where(r => r.Name.StartsWith(name))
                .OrderBy(r => r.Name);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = context.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;

            return updatedRestaurant;
        }
    }
}