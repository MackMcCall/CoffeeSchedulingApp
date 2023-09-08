namespace CoffeeSchedulingApp.Models.CoffeeModelsRepos
{
    public interface ICoffeeRepo
    {
        public void InsertCoffee(Coffee coffeeToInsert);
        public Coffee GetCoffee(int coffeeID);
        public void UpdateCoffee(Coffee coffee);
        public void DeleteCoffee(Coffee coffee);
    }
}
