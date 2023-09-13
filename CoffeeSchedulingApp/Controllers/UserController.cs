﻿using CoffeeSchedulingApp.Models.InventoryModelsRepos;
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
            return RedirectToAction("Index", "Inventory");  
        }
    }
}