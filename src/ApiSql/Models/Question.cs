using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSql.Models;

public class Question
{
    [Key]
    public int QuestionId { get; set; }
    public required string Title { get; set; }

    public int? QuizId { get; set; }

    [ForeignKey(nameof(QuizId))]
    public virtual Quiz? Quiz { get; set; }

    public int AnswerId { get; set; }

    [ForeignKey(nameof(AnswerId))]
    public virtual Answer Answer { get; set; } = new() { IsCorrect = false };
}