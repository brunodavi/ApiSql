using System.ComponentModel.DataAnnotations;

namespace ApiSql.Models;

public class Author
{
    [Key]
    public int AuthorId { get; set; }

    [Required]
    [StringLength(200)]
    public required string Name { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    public ICollection<Book> Books { get; set; }

    public Author()
    {
        Books = [];
    }
}