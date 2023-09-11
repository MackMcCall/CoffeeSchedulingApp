using CoffeeSchedulingApp.Models.InventoryModelsRepos;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeSchedulingApp.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryRepo _repo;

        public InventoryController(IInventoryRepo repo)
        {
            _repo = repo;
        }
        
        public IActionResult Index()
        {
            var userCoffeeBags = _repo.GetAllUserBags(1);
            return View(userCoffeeBags);
        }

        
    }
}

//controls the inventory view folder