using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSql.Models;

public class Answer
{
    [Key]
    public int AnswerId { get; set; }
    public required bool IsCorrect { get; set; }

    public int? QuestionId { get; set; }

    [ForeignKey(nameof(QuestionId))]
    public virtual Question? Question { get; set; }
}