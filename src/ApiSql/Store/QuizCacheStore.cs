using ApiSql.Models;
using ApiSql.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace ApiSql.Store;

public class QuizCachesStore(IMemoryCache memoryCache, IQuizRepository quizRepository)
{
    public Quiz? GetQuiz(int quizId)
        => memoryCache.GetOrCreate($"{nameof(Quiz)}:{quizId}", _ => quizRepository.GetQuiz(quizId));

    public List<Quiz> GetQuizzes()
        => memoryCache.GetOrCreate("quizzes", _ => quizRepository.GetQuizzes()) ?? [];
}