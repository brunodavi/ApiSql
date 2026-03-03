using ApiSql.Repositories;
using ApiSql.Tests.Fixtures;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace ApiSql.Tests.Controllers;

public class QuizCacheTest : IClassFixture<AppQuizContextFixture<Program>>
{
    private readonly HttpClient _client;
    private readonly Mock<IQuizRepository> _mockQuizRepository;

    public QuizCacheTest(AppQuizContextFixture<Program> factory)
    {
        _mockQuizRepository = new();

        _client = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(service =>
            {
                service.AddScoped(options => _mockQuizRepository.Object);
            });
        }).CreateClient();
    }

    [Fact]
    public async Task ShouldRequestCachedQuiz()
    {
        await _client.GetAsync("/quiz");
        await _client.GetAsync("/quiz");

        var response = await _client.GetAsync("/quiz");
        response.IsSuccessStatusCode.Should().BeTrue();

        _mockQuizRepository.Verify(x => x.GetQuizzes(), Times.Once());
    }
}