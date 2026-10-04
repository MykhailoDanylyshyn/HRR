namespace HomeRepairReviews.Models;

public class FeedbackPhoto
{
    public int Id { get; set; }

    public string PhotoPath { get; set; } = "";

    public int FeedbackId { get; set; }

    public Feedback Feedback { get; set; } = null!;
}
