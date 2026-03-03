using ApiSql.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiSql.Controllers;

[ApiController]
[Route("[controller]")]
public class QuizController(QuizRepository repository) : ControllerBase
{
    [HttpGet]
    public IActionResult GetQuizzes()
    {
        var quizzes = repository.GetQuizzes();
        return Ok(quizzes);
    }
}