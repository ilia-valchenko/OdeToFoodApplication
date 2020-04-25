using System.Collections.Generic;
using OdeToFood.Core.Entities;

namespace OdeToFood.DataAccess.Repositories.Interfaces
{
    public interface IRestaurantRepository
    {
        Restaurant Create(Restaurant newRestaurant);

        IEnumerable<Restaurant> Get();

        Restaurant Get(int id);

        int GetCount();

        IEnumerable<Restaurant> Search(string name);

        Restaurant Update(Restaurant updatedRestaurant);

        Restaurant Delete(int id);

        int Commit();
    }
}