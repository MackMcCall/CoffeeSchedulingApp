using CoffeeSchedulingApp.Models.CoffeeModelsRepos;
using Microsoft.AspNetCore.Mvc;

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


    }
}

//controls the things related to the coffee views