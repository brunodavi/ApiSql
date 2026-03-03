using ApiSql.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSql.Database;

public class QuizContext(DbContextOptions<QuizContext> options) : DbContext(options)
{
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
}