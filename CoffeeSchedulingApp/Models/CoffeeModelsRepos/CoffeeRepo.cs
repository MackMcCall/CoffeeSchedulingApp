using Dapper;
using Microsoft.AspNetCore.Components.Routing;
using System.Data;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace CoffeeSchedulingApp.Models.CoffeeModelsRepos
{
    public class CoffeeRepo : ICoffeeRepo
    {
        private readonly IDbConnection _conn;

        public CoffeeRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public void InsertCoffee(Coffee coffeeToInsert)
        {
            _conn.Execute("INSERT INTO coffees " +
                "(CoffeeID, Roaster, Producer, Country, Region, Variety, Process, RoastDate, DaysRestNeeded, ReadyToDrink, Grams)" +
                "VALUES (@coffeeID, @roaster, @producer, @country, @region, @variety, @process, @roastDate, @daysRestNeeded, @readyToDrink, @grams);",
            new
            {
                coffeeID = coffeeToInsert.CoffeeID,
                roaster = coffeeToInsert.Roaster,
                producer = coffeeToInsert.Producer,
                country = coffeeToInsert.Country,
                region = coffeeToInsert.Region,
                variety = coffeeToInsert.Variety,
                process = coffeeToInsert.Process,
                roastDate = coffeeToInsert.RoastDate,
                daysRestNeeded = coffeeToInsert.DaysRestNeeded,
                readyToDrink = coffeeToInsert.ReadyToDrink,
                grams = coffeeToInsert.Grams
            });
        }
        public Coffee GetCoffee(int coffeeID)
        {
            return _conn.QuerySingle<Coffee>("SELECT * FROM coffees WHERE CoffeeID = @coffeeID", new { coffeeID });
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
                "Grams = @grams" +
                "WHERE CoffeeID = @coffeeID",
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
                    grams = coffee.Grams
                });
        }

        public void DeleteCoffee(Coffee coffee)
        {
            _conn.Execute("DELETE FROM coffees WHERE CoffeeID = @coffeeID", new { coffeeID = coffee.CoffeeID });
        }
    }
}
