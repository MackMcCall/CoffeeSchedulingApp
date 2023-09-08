using CoffeeSchedulingApp.Models.CoffeeModelsRepos;
using CoffeeSchedulingApp.Models.UserModelsRepos;

namespace CoffeeSchedulingApp.Models.InventoryModelsRepos
{
    public interface IInventoryRepo
    {

        public void InsertUserBag(Inventory userBagToInsert);

        public IEnumerable<Coffee> GetAllUserBags(User user);

        public Coffee GetUserBag(int coffeeID);

        public void UpdateUserBag(Inventory userBag);

        public void DeleteUserBag(Inventory userBag);
    }
}
