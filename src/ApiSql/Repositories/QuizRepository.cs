using ApiSql.Database;
using ApiSql.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ApiSql.Repositories;

public class QuizRepository(QuizContext context, IMemoryCache memoryCache)
{
    private readonly DbSet<Quiz> dbSetQuiz = context.Set<Quiz>();
    private QuizCacheStore QuizCacheStore => new(memoryCache, this);

    public Quiz? GetQuiz(int quizId) => QuizCacheStore.Get(quizId);

    public List<Quiz> GetQuizzes() => dbSetQuiz.ToList();
}