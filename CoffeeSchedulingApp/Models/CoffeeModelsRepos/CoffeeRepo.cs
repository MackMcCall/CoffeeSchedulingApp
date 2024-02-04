using Dapper;
using Microsoft.AspNetCore.Components.Routing;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Transactions;
using CoffeeSchedulingApp.Models.UserModelsRepos;

namespace CoffeeSchedulingApp.Models.CoffeeModelsRepos
{
    public class CoffeeRepo : ICoffeeRepo
    {
        private readonly IDbConnection _conn;

        public CoffeeRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public void InsertCoffee(Coffee coffeeToInsert, int userID)
        {
            _conn.Execute("INSERT INTO coffees " +
                "(Roaster, Producer, Country, Region, Variety, Process, RoastDate, DaysRestNeeded, ReadyToDrink, Grams)" +
                "VALUES (@roaster, @producer, @country, @region, @variety, @process, @roastDate, @daysRestNeeded, @readyToDrink, @grams, @isArchived);",
            new
            {
                roaster = coffeeToInsert.Roaster,
                producer = coffeeToInsert.Producer,
                country = coffeeToInsert.Country,
                region = coffeeToInsert.Region,
                variety = coffeeToInsert.Variety,
                process = coffeeToInsert.Process,
                roastDate = coffeeToInsert.RoastDate,
                daysRestNeeded = coffeeToInsert.DaysRestNeeded,
                readyToDrink = coffeeToInsert.ReadyToDrink,
                grams = coffeeToInsert.Grams,
                isArchived = coffeeToInsert.IsArchived
            });
            
            @coffeeToInsert.CoffeeID = Convert.ToInt32(_conn.ExecuteScalar("SELECT LAST_INSERT_ID();", coffeeToInsert));

            _conn.Execute("INSERT INTO inventories (CoffeeID, UserID) VALUES (@coffeeID, @userID);",
                new { coffeeToInsert.CoffeeID, userID });
        }
        public Coffee GetCoffee(int id)
        {
            return _conn.QuerySingle<Coffee>("SELECT * FROM coffees WHERE CoffeeID = @id", new { id });
        }

        public void UpdateCoffee(Coffee coffee)
        {
            _conn.Execute("UPDATE coffees SET " +
                "Roaster = @roaster, " +
                "Producer = @producer, " +
                "Country = @country, " +
                "Region = @region, " +
                "Variety = @variety, " +
                "Process = @process, " +
                "RoastDate = @roastDate, " +
                "DaysRestNeeded = @daysRestNeeded, " +
                "ReadyToDrink = @readyToDrink, " +
                "Grams = @grams, " +
                "IsArchived = @isArchived " +
                "WHERE CoffeeID = @id",
                new
                {
                    roaster = coffee.Roaster,
                    producer = coffee.Producer,
                    country = coffee.Country,
                    region = coffee.Region,
                    variety = coffee.Variety,
                    process = coffee.Process,
                    roastDate = coffee.RoastDate,
                    daysRestNeeded = coffee.DaysRestNeeded,
                    readyToDrink = coffee.ReadyToDrink,
                    grams = coffee.Grams,
                    isArchived = coffee.IsArchived,
                    id = coffee.CoffeeID
                });
        }

        
        public void ArchiveCoffee(Coffee coffee)
        {
            _conn.Execute("UPDATE coffees SET " +
                "IsArchived = @isArchived" +
                "WHERE CoffeeID = @id",
                new
                {
                    isArchived = coffee.IsArchived,
                    id = coffee.CoffeeID
                });
        }

        public void DeleteCoffee(Coffee coffee)
        {
            _conn.Execute("DELETE FROM inventories WHERE CoffeeID = @id; DELETE FROM coffees WHERE CoffeeID = @id;", new { id = coffee.CoffeeID });
        }
    }
}
