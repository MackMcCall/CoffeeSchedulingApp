using Dapper;
using Org.BouncyCastle.Bcpg;
using System.Data;

namespace CoffeeSchedulingApp.Models
{
    public class UserRepo : IUserRepo
    {
        private readonly IDbConnection _conn;

        public UserRepo(IDbConnection conn)
        {
            _conn = conn;
        } 

        public void InsertUser(User userToInsert)
        {
            _conn.Execute("INSERT INTO users (Name) VALUES (@userID, @name);", 
                new { name = userToInsert.Name });
        }

        public void UpdateUser(User user)
        {
            _conn.Execute("UPDATE users SET Name = @name WHERE UserID = @userID", 
                new { name = user.Name, userID = user.UserID });
        }

        public void DeleteUser(User user)
        {
            _conn.Execute("DELETE FROM users WHERE UserID = @userID", new { userID = user.UserID });
        }
    }
}
