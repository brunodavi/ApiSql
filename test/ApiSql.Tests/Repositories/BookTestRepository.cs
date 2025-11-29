using ApiSql.Models;
using ApiSql.Repositories;
using ApiSql.Tests.Database;
using FluentAssertions;

namespace ApiSql.Tests.Repositories;

public class BookTestRepository
{
    [Fact]
    public void ShouldCreateBook()
    {
        var context = new BookTestContext();
        var repository = new BookRepository(context);

        var book = new Book()
        {
            Title = "O Gato de Botas",
            Description = "Uma história envolvente de um gato e suas botas",
            Genre = "Ação",
            Year = 1949,
            Pages = 5,

            Author = new()
            {
                Name = "Um Humano",
                Email = "human@mail.com"
            },

            Publisher = new()
            {
                Name = "Uma Pessoa",
                Email = "anon@mail.com"
            }
        };

        repository.Add(book);

        var books = repository.GetBooks();

        books.Count.Should().Be(1);
        books.First().Should().Be(book);
    }
}