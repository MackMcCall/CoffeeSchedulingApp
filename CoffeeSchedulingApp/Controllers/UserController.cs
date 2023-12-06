using CoffeeSchedulingApp.Models.CoffeeModelsRepos;
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
            try
            {
                return View(user);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult GetUserBags(User user)
        {
            try
            {
                var id = user.UserID;

                // Storing data in the session
                HttpContext.Session.SetInt32("UserID", id);

                // Retrieving data from the session
                var userID = HttpContext.Session.GetInt32("UserID");

                return RedirectToAction("Index", "Inventory");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult UpdateUserAvgGramsPerDay(int id)
        {
            User user = _repo.GetUser(id);
            return View(user);
        }

        public IActionResult UpdateUserAvgGramsPerDayToDatabse(User user)
        {
            _repo.UpdateUserAvgGramsPerDay(user);

            return RedirectToAction("Index", "Inventory", new { id = user.UserID});
        }
    }
}
