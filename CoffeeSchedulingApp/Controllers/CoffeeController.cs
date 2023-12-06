using CoffeeSchedulingApp.Models.CoffeeModelsRepos;
using CoffeeSchedulingApp.Models.UserModelsRepos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace CoffeeSchedulingApp.Controllers
{
    public class CoffeeController : Controller
    {
        private readonly ICoffeeRepo _repo;

        public CoffeeController(ICoffeeRepo repo)
        {
            _repo = repo;
        }

        public IActionResult ViewCoffee(int id)
        {
            var coffee = _repo.GetCoffee(id);
            return View(coffee);
        }

        public IActionResult UpdateCoffee(int id)
        {
            Coffee coffee = _repo.GetCoffee(id);
            return View(coffee);
        }

        public IActionResult UpdateCoffeeToDatabase(Coffee coffee)
        {
            _repo.UpdateCoffee(coffee);

            return RedirectToAction("ViewCoffee", new { id = coffee.CoffeeID });
        }

        public IActionResult InsertCoffee(Coffee coffeeToInsert)
        {
            return View(coffeeToInsert);
        }

        public IActionResult InsertCoffeeToDatabase(Coffee coffeeToInsert)
        {
            try
            {
                _repo.InsertCoffee(coffeeToInsert, Convert.ToInt32(HttpContext.Session.GetInt32("UserID")));
                return RedirectToAction("Index", "Inventory");
            }
            catch(Exception e)
            {
                return RedirectToAction("Index", "Inventory");
            }
        }

        public IActionResult DeleteCoffee(Coffee coffee)
        {
            _repo.DeleteCoffee(coffee);
            return RedirectToAction("Index", "Inventory");
        }
    }
}

//controls the things related to the coffee views