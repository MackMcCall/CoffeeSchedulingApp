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

        //public Coffee GetUserBag(int coffeeID)
        //{
        //    return _conn.QuerySingle<Coffee>("SELECT Roaster, Producer, Country, Region, Variety, Process, RoastDate, DaysRestNeeded, ReadyToDrink, Grams " +
        //        "FROM coffees AS c " +
        //        "INNER JOIN inventories AS i " +
        //        "ON c.CoffeeID = i.CoffeeID " +
        //        "WHERE c.CoffeeID = @coffeeID;", new { coffeeID });
        //}

        public IEnumerable<Coffee> GetAllUserBags(int userID)
        {
            return _conn.Query<Coffee>("SELECT c.CoffeeID, Roaster, Producer, Country, Region, Variety, Process, RoastDate, DaysRestNeeded, ReadyToDrink, Grams " +
                "FROM coffees AS c " +
                "INNER JOIN inventories AS i " +
                "ON c.CoffeeID = i.CoffeeID " +
                "WHERE UserID = @userID;", new { userID });
        }
    }
}
