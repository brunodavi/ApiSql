using ApiSql.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace ApiSql.Models;

public class QuizCacheStore(IMemoryCache memoryCache, QuizRepository quizRepository)
{
    private readonly IMemoryCache _memoryCache = memoryCache;
    private readonly QuizRepository _quizRepository = quizRepository;
    private readonly string _cacheKey = "quizzes";

    private static string GetKey(string key)
    {
        return $"{typeof(Quiz).Name}:{key}";
    }

    public Quiz? Get(int quizId)
    {
        string key = GetKey(quizId.ToString());
        var item = _memoryCache.Get<Quiz>(key);

        if (item == null)
        {
            item = _quizRepository.GetQuiz(quizId);

            if (item != null)
            {
                _memoryCache.Set(key, item);
            }
        }

        return item;
    }
}