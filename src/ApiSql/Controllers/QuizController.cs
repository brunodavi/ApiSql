using ApiSql.Store;
using Microsoft.AspNetCore.Mvc;

namespace ApiSql.Controllers;

[ApiController]
[Route("[controller]")]
public class QuizController(QuizCachesStore quizCachesStore) : ControllerBase
{
    [HttpGet]
    public IActionResult GetQuizzes()
    {
        var quizzes = quizCachesStore.GetQuizzes();
        return Ok(quizzes);
    }
}