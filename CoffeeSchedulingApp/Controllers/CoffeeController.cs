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
        
        public IActionResult Insert()
        {
            return View();
        }
    }
}

//controls the things related to the coffee views