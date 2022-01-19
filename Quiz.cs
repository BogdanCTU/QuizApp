using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace QuizApp
{
    public class Quiz
    {
        [Key]
        public int IDQuiz { get; set; }
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string CorectAnswer { get; set; }
    }

    public class QuizDbContext : DbContext
    {
        public DbSet<Quiz> Quizes { get; set; }
    }
}
