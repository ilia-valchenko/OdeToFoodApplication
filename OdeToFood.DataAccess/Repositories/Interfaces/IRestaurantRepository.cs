using System.Collections.Generic;
using OdeToFood.Core.Entities;

namespace OdeToFood.DataAccess.Repositories.Interfaces
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> Get();

        IEnumerable<Restaurant> Search(string name);
    }
}