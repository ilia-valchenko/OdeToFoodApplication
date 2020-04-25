using Microsoft.AspNetCore.Mvc;
using OdeToFood.DataAccess.Repositories.Interfaces;

namespace OdeToFoodApplication.ViewComponents
{
    public sealed class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantRepository repository;

        public RestaurantCountViewComponent(IRestaurantRepository repository)
        {
            this.repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var count = repository.GetCount();
            return View(count);
        }
    }
}