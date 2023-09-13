using CoffeeSchedulingApp.Models.CoffeeModelsRepos;
using CoffeeSchedulingApp.Models.UserModelsRepos;

namespace CoffeeSchedulingApp.Models
{
    public class UserCoffeeViewModel
    {
        public User ModelUser { get; set; }
        public Coffee ModelCoffee { get; set; }
        public int UserAvgGrams { get; set; }
        public int CoffeeTotalGrams { get; set; }


    }
}
