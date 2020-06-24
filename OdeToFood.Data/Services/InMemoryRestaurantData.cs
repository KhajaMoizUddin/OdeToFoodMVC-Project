using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {

               new Restaurant() { Id = 1, Name = "Scott's Pizza", Cuisine = CuisineType.Italian},
                new Restaurant(){ Id = 2, Name = "Tersiguels", Cuisine = CuisineType.French},
               new Restaurant() { Id = 3, Name = "Mango Grove", Cuisine = CuisineType.Indian},
            };

        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(x => x.Id == id);
        }

        IEnumerable<Restaurant> IRestaurantData.GetAll()
        {
            return restaurants.OrderBy(x => x.Name);
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
           restaurant.Id =  restaurants.Max(x => x.Id) + 1;
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
            if(existing!=null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
        }

        Restaurant IRestaurantData.Get(int id)
        {
            throw new NotImplementedException();
        }

        void IRestaurantData.Add(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        void IRestaurantData.Update(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        void IRestaurantData.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
