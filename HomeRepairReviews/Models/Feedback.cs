using System.ComponentModel.DataAnnotations;

namespace HomeRepairReviews.Models;

public class Feedback
{
    public int Id { get; set; }

    public string UserName { get; set; } = "";

    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Введіть ім'я майстра")]
    public string Master { get; set; } = "";

    [Required(ErrorMessage = "Введіть вид робіт")]
    public string WorkType { get; set; } = "";

    [Required(ErrorMessage = "Введіть текст відгуку")]
    public string Text { get; set; } = "";

    public List<FeedbackPhoto> Photos { get; set; } = new();
}
