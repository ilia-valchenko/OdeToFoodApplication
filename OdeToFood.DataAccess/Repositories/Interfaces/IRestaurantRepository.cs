using System.Collections.Generic;
using OdeToFood.Core.Entities;

namespace OdeToFood.DataAccess.Repositories.Interfaces
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> Get();

        Restaurant Get(int id);

        IEnumerable<Restaurant> Search(string name);

        Restaurant Update(Restaurant updatedRestaurant);

        int Commit();
    }
}