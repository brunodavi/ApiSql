using ApiSql.Database;
using ApiSql.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSql.Repositories;

public interface IQuizRepository
{
    Quiz? GetQuiz(int quizId);
    List<Quiz> GetQuizzes();
}

public class QuizRepository(QuizContext context) : IQuizRepository
{
    private readonly DbSet<Quiz> quizzes = context.Quizzes;

    public virtual Quiz? GetQuiz(int quizId) => quizzes.FirstOrDefault(quiz => quiz.QuizId == quizId);
    public virtual List<Quiz> GetQuizzes() => quizzes.ToList();
}