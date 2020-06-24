using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.MVC.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantsController(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        // GET: Restaurants
        public ActionResult Index()
        {
            var model = this.restaurantData.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = this.restaurantData.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            //if (string.IsNullOrEmpty(restaurant.Name))  // Instead we can use Required annotation at Model level.
            //{
            //    ModelState.AddModelError(nameof(restaurant.Name), "This is Required field!");
            //}

            if (ModelState.IsValid)
            {
                this.restaurantData.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
           var model = this.restaurantData.Get(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                this.restaurantData.Update(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                this.restaurantData.Delete(id);
                return RedirectToAction("Index");
            }
            
            return View();
        }
    }
}