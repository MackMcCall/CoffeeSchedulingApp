namespace CoffeeSchedulingApp.Models.UserModelsRepos
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public int AvgGramsPerDay { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        private string HashedPassword { get; set; }

        public void SetPassword(string plainTextPassword)
        {
            throw new NotImplementedException();
        }

        public bool VerifyPassword(string plainTextPassword)
        {
            throw new NotImplementedException();
        }

        public string HashPassword(string plainTextPassword)
        {
            throw new NotImplementedException();
        }

        public string VerifyPasswordHash(string enteredPassword, string storedHash)
        {
            throw new NotImplementedException();
        }
    }
}
