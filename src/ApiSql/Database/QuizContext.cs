using ApiSql.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSql.Database;

public class QuizContext : DbContext
{
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=model;User=SA;Password=Password12!;");
    }
}