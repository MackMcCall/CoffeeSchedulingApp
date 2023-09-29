using CoffeeSchedulingApp.Models.CoffeeModelsRepos;
using Dapper;
using Org.BouncyCastle.Bcpg;
using System.Data;

namespace CoffeeSchedulingApp.Models.UserModelsRepos
{
    public class UserRepo : IUserRepo
    {
        private readonly IDbConnection _conn;

        public UserRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public User GetUser(int id)
        {
            return _conn.QuerySingle<User>("SELECT * FROM users WHERE UserID = @id;", new { id });
        }

        public void InsertUser(User userToInsert)
        {
            _conn.Execute("INSERT INTO users (Name) VALUES (@userID, @name);",
                new { name = userToInsert.Name });
        }

        public void UpdateUser(User user)
        {
            _conn.Execute("UPDATE users SET Name = @name WHERE UserID = @userID;",
                new { name = user.Name, userID = user.UserID });
        }

        public void DeleteUser(User user)
        {
            _conn.Execute("DELETE FROM users WHERE UserID = @userID;", new { userID = user.UserID });
        }

        public void UpdateUserAvgGramsPerDay(User user)
        {
            _conn.Execute("UPDATE users SET AvgGramsPerDay = @avgGramsPerDay WHERE UserID = @userID;",
                new { userID = user.UserID, avgGramsPerDay = user.AvgGramsPerDay });
        }
    }
}
