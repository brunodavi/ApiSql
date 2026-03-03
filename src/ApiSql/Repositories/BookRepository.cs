using ApiSql.Database;
using ApiSql.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSql.Repositories;

public class BookRepository(BookContext context)
{
    private readonly DbSet<Book> dbSetBook = context.Set<Book>();

    public List<Book> GetBooks() => dbSetBook.ToList();
    public Book GetById(int id)
    {
        return dbSetBook
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .First(b => b.BookId == id);
    }

    public Book Add(Book book)
    {
        context.Add(book);
        context.SaveChanges();
        return book;
    }

    public virtual void Update(Book book)
    {
        context.Update(book);
        context.SaveChanges();
    }
    
    public virtual void Delete(int id)
    {
        var book = dbSetBook
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .Single(b => b.BookId == id);

        context.Remove(book);
        context.Remove(book.Author);
        context.Remove(book.Publisher);

        context.SaveChanges();
    }
}