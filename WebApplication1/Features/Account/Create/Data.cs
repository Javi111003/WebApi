using Microsoft.EntityFrameworkCore;

namespace Account.Create
{
    public class Account
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Passsword { get; set; }
        public Account(string first, string last, string username, string emailadrress, int age, string password)
        {
            FirstName = first;
            LastName = last;
            Username = username;
            Email = emailadrress;
            Age = age;
            Passsword = password;
        }
    }
    public class Context : DbContext
    {
        public DbSet<Account> accounts { get; set; }
    }
}