using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
   public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

       public void Add(Restaurant restaurant)
        {
            this.db.Restaurants.Add(restaurant);
            this.db.SaveChanges();
        }

       public Restaurant Get(int id)
        {
            return this.db.Restaurants.FirstOrDefault(x => x.Id == id);
        }

       public IEnumerable<Restaurant> GetAll()
        {
            //this.db.Restaurants.OrderBy(x=>x.Name);
            return from r in db.Restaurants
                   orderby r.Name
                   select r;
        }

        public void Update(Restaurant restaurant)
        {
            //var entry = db.Entry(restaurant);
            //entry.State = System.Data.Entity.EntityState.Modified;
           // db.SaveChanges();

            var update = Get(restaurant.Id);
            update.Name = restaurant.Name;
            update.Cuisine = restaurant.Cuisine;
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var getRestaurant = Get(id);
            this.db.Restaurants.Remove(getRestaurant);
            this.db.SaveChanges();
        }
    }
}
