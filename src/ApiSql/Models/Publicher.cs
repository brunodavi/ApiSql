using System.ComponentModel.DataAnnotations;

namespace ApiSql.Models;

public class Publisher
{
    [Key]
    public int AuthorId { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    public ICollection<Book> Books { get; set; }

    public Publisher()
    {
        Books = [];
    }
}