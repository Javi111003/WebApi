using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Posts.Create;

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
        public ICollection<User> Followers { get; set; }
        public ICollection<User> Following { get; set; }

        public ICollection<Post> MyBlog { get; set; }

    }
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

    }
}