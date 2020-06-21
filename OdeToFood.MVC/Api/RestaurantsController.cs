using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OdeToFood.Data.Models;
using OdeToFood.Data.Services;

namespace OdeToFood.MVC.Api
{
    public class RestaurantsController : ApiController
    {
        public readonly IRestaurantData db;
        public RestaurantsController(IRestaurantData data)
        {
            this.db = data;
        }

        public IEnumerable<Restaurant> Get()
        {
            var modelRestaurants = this.db.GetAll();
            return modelRestaurants;
        }
    }
}
