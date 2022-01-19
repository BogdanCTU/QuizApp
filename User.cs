using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace QuizApp
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [MaxLength(30, ErrorMessage = "User's name max lenght is 30")]
        public string UserUsername { get; set; }
        public string UserPassword { get; set; }
        public int UserPoints { get; set; }
    }

    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }

    //EOF
}