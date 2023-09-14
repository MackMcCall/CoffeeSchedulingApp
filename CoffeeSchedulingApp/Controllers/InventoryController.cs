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
            var inventoryVM = new InventoryViewModel { ModelCoffees = _repo.GetAllUserBags(id), ModelUser = _repo.GetUser(id) };
            return View(inventoryVM);

            //var userData = 

            //var userCoffeeBags = _repo.GetAllUserBags(id);

            //return View(userCoffeeBags);
        }
    }
}

//controls the inventory view folder