﻿using CoffeeSchedulingApp.Models.CoffeeModelsRepos;
using CoffeeSchedulingApp.Models.UserModelsRepos;
using Dapper;
using System.Data;
namespace CoffeeSchedulingApp.Models.InventoryModelsRepos
{
    public class InventoryRepo : IInventoryRepo
    {
        private readonly IDbConnection _conn;

        public InventoryRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Coffee> GetAllUserBags(int userID)
        {
            return _conn.Query<Coffee>("SELECT c.CoffeeID, Roaster, Producer, Country, Region, Variety, Process, RoastDate, DaysRestNeeded, ReadyToDrink, Grams " +
                "FROM coffees AS c " +
                "INNER JOIN inventories AS i " +
                "ON c.CoffeeID = i.CoffeeID " +
                "WHERE UserID = @userID;", new { userID });
        }

        public User GetUser(int userID)
        {
            return _conn.QuerySingle<User>("SELECT * FROM users WHERE UserId = @userID;", new { userID });
        }
    }
}
