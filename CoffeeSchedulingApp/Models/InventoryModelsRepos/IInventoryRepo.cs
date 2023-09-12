using CoffeeSchedulingApp.Models.CoffeeModelsRepos;
using CoffeeSchedulingApp.Models.UserModelsRepos;

namespace CoffeeSchedulingApp.Models.InventoryModelsRepos
{
    public interface IInventoryRepo
    {

        public void InsertUserBag(Inventory userBagToInsert);

        public IEnumerable<Coffee> GetAllUserBags(int userID);

        public void DeleteUserBag(Inventory userBag);
    }
}
