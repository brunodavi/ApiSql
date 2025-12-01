using System.ComponentModel.DataAnnotations;

namespace ApiSql.Models;

public class Quiz
{
    [Key]
    public int QuizId { get; set; }
    public required string Description { get; set; }

    public virtual ICollection<Question>? Questions { get; set; }
}