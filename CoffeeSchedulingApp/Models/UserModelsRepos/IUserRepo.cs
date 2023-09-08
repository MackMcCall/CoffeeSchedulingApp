namespace CoffeeSchedulingApp.Models.UserModelsRepos
{
    public interface IUserRepo
    {
        public void InsertUser(User userToInsert);
        public void UpdateUser(User user);
        public void DeleteUser(User user);
    }
}
