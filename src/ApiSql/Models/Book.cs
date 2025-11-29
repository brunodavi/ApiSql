using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSql.Models;

public class Book
{
    [Key]
    public int BookId { get; set; }

    [Required]
    [StringLength(100)]
    public required string Title { get; set; }

    [Required]
    public required int Pages { get; set; }

    [StringLength(5000)]
    public string? Description { get; set; }
    public string? Genre { get; set; }
    public int Year { get; set; }

    [ForeignKey(nameof(AuthorId))]
    public int? AuthorId { get; set; }
    public required Author Author { get; set; }

    [ForeignKey(nameof(PublisherId))]
    public int? PublisherId { get; set; }
    public required Publisher Publisher { get; set; }
}