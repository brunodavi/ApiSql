using System.Data.Common;
using ApiSql.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiSql.Tests.Fixtures;

public class AppQuizContextFixture<TEntryPoint> : WebApplicationFactory<TEntryPoint>
    where TEntryPoint : Program
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<QuizContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            var dbConnectionDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbConnection));

            if (dbConnectionDescriptor != null)
            {
                services.Remove(dbConnectionDescriptor);
            }

            services.AddDbContext<QuizContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryQuizTest");
            });

            using var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();

            var scopedServices = scope.ServiceProvider;
            var appContext = scopedServices.GetRequiredService<QuizContext>();

            appContext.Database.EnsureCreated();
        });
    }
}