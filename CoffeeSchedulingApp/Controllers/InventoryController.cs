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
            try
            {
                int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
                var inventoryVM = new InventoryViewModel { ModelCoffees = _repo.GetAllUserBags(id), ModelUser = _repo.GetUser(id) };
                return View(inventoryVM);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}

//controls the inventory view folder