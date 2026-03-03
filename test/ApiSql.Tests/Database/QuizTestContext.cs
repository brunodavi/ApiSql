using ApiSql.Database;
using Microsoft.EntityFrameworkCore;

namespace ApiSql.Tests.Database;

public class QuizTestContext(DbContextOptions<QuizContext> options) : QuizContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // var serviceProvider = new ServiceCollection()
        //     .AddEntityFrameworkInMemoryDatabase()
        //     .BuildServiceProvider();

        // optionsBuilder
        //     .UseInMemoryDatabase("Quizzes")
        //     .UseInternalServiceProvider(serviceProvider);

        optionsBuilder.UseInMemoryDatabase("Quizzes")
            .UseLazyLoadingProxies();
    }
}
