using ApiSql.Models;
using ApiSql.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiSql.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController(BookRepository repository) : ControllerBase
{
    [HttpPost]
    public IActionResult AddBook(Book book)
    {
        repository.Add(book);
        return Ok(book);
    }
}