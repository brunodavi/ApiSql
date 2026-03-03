using ApiSql.Tests.Fixtures;
using FluentAssertions;

namespace ApiSql.Tests.Controllers;

public class QuizTest : IClassFixture<AppQuizContextFixture<Program>>
{
    private readonly HttpClient _client;

    public QuizTest(AppQuizContextFixture<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ShouldRequestQuiz()
    {
        var response = await _client.GetAsync("/quiz");
        response.IsSuccessStatusCode.Should().BeTrue();
    }
}