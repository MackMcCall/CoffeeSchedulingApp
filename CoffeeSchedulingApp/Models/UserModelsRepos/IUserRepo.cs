namespace CoffeeSchedulingApp.Models.UserModelsRepos
{
    public interface IUserRepo
    {
        public void InsertUser(User userToInsert);
        public User GetUser(int userID);
        public void UpdateUser(User user);
        public void DeleteUser(User user);
    }
}
