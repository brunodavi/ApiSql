using ApiSql.Models;
using ApiSql.Tests.Database;
using FluentAssertions;

namespace ApiSql.Tests.Repositories;

public class QuizTestRepository
{
    [Fact]
    public void ShouldCreateQuiz()
    {
        // Arrange
        using var context = new QuizTestContext(new());

        List<Question> questions = [
            new()
            {
                QuestionId = 1,
                Title = "Porco",
                Answer = new() { IsCorrect = true }
            },
            new()
            {
                QuestionId = 2,
                Title = "Vaca",
            },
            new()
            {
                QuestionId = 3,
                Title = "Cavalo",
            },
        ];

        List<Answer> answers = [.. questions.Select(q => q.Answer)];

        Quiz quiz = new()
        {
            Description = "Que animal é esse: 🐷?",
            Questions = questions,
        };

        // Act
        context.Quizzes.Add(quiz);
        context.SaveChanges();

        // Assert
        var quizList = context.Quizzes.ToList();
        var quizSaved = quizList.First();

        var questionList = quizSaved.Questions?.ToList();
        var answerList = questionList?.Select(q => q.Answer).ToList();

        quizList.Count.Should().Be(1);
        questionList?.Count.Should().Be(3);
        answerList?.Count.Should().Be(3);

        quizSaved.Should().Be(quizSaved);
        questionList?.Should().BeEquivalentTo(questions);
        answerList?.Should().BeEquivalentTo(answers);
    }
}