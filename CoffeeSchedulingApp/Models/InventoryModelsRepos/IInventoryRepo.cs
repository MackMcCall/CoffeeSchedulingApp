using CoffeeSchedulingApp.Models.CoffeeModelsRepos;
using CoffeeSchedulingApp.Models.UserModelsRepos;

namespace CoffeeSchedulingApp.Models.InventoryModelsRepos
{
    public interface IInventoryRepo
    {
        public IEnumerable<Coffee> GetAllUserBags(int userID);
    }
}
