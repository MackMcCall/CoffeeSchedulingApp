using CoffeeSchedulingApp.Models.InventoryModelsRepos;
using CoffeeSchedulingApp.Models.UserModelsRepos;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeSchedulingApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepo _repo;
        private readonly IInventoryRepo _inventoryRepo;

        public UserController(IUserRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Login(User user)
        {
            return View(user);
        }

        public IActionResult GetUserBags(User user)
        {
            var id = user.UserID;
            TempData["id"] = id;
            // Storing data in the session
            HttpContext.Session.SetInt32("UserID", id);

            // Retrieving data from the session
            string userName = HttpContext.Session.GetString("UserName");

            return RedirectToAction("Index", "Inventory");  
        }
    }
}
