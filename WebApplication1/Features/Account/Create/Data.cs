using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Account.Create
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Key]
        public string Username { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Passsword { get; set; }

    }
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}