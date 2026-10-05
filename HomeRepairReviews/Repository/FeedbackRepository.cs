using HomeRepairReviews.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeRepairReviews.Repositories;

public class FeedbackRepository(FeedbackContext context) : IRepository
{
    public async Task<List<Feedback>> GetAllAsync()
    {
        return await context.Feedbacks
        .Include(f => f.Photos)
        .OrderByDescending(f => f.Date)
        .ToListAsync();
    }
public async Task<Feedback?> GetByIdAsync(int id)
    {
        return await context.Feedbacks
            .Include(f => f.Photos)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task AddAsync(Feedback feedback)
    {
        context.Feedbacks.Add(feedback);
        await context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }

    public void Delete(Feedback feedback)
    {
        context.Feedbacks.Remove(feedback);
    }
}
