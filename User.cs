using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Laborator5_proj
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [MaxLength(30, ErrorMessage = "User's name max lenght is 30")]
        public string UserName { get; set; }
        [MaxLength(30, ErrorMessage = "User's surname max lenght is 30")]
        public string UserSurname { get; set; }
        [MaxLength(30, ErrorMessage = "User's username max lenght is 30")]
        public string UserUsername { get; set; }
        public string UserPassword { get; set; }
    }

    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }

    //EOF
}