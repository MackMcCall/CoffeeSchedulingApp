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
            int id = (int)TempData["id"];
            var userCoffeeBags = _repo.GetAllUserBags(id);
            return View(userCoffeeBags);
        }
    }
}

//controls the inventory view folder