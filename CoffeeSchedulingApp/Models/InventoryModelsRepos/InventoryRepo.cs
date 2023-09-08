using CoffeeSchedulingApp.Models.CoffeeModelsRepos;
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

        public void InsertUserBag(Inventory userBagToInsert)
        {
            _conn.Execute("INSERT INTO inventories (CoffeeID, UserID) VALUES (@coffeeID, userID)",
                     new { coffeeID = userBagToInsert.CoffeeID, userID = userBagToInsert.UserID });
        }

        public Coffee GetUserBag(int coffeeID)
        {
            return _conn.QuerySingle<Coffee>("SELECT Roaster, Producer, Country, Region, Variety, Process, RoastDate, DaysRestNeeded, ReadyToDrink, Grams " +
                "FROM coffees AS c " +
                "INNER JOIN inventories AS i " +
                "ON c.CoffeeID = i.CoffeeID " +
                "WHERE c.CoffeeID = @coffeeID;", new { coffeeID });
        }

        public IEnumerable<Coffee> GetAllUserBags(User user)
        {
            return _conn.Query<Coffee>("SELECT Roaster, Producer, Country, Region, Variety, Process, RoastDate, DaysRestNeeded, ReadyToDrink, Grams " +
                "FROM coffees AS c " +
                "INNER JOIN inventories AS i " +
                "ON c.CoffeeID = i.CoffeeID " +
                "WHERE UserID = @userID;", new { userID = user.UserID });
        }

        public void UpdateUserBag(Inventory userBag)
        {
            //_conn.Execute("UPDATE inventories SET ")
        }

        public void DeleteUserBag(Inventory userBag)
        {
            _conn.Execute("DELETE FROM inventories WHERE UserBagID = @userBagID;", new { userBagID = userBag.UserBagID });
        }
    }
}
