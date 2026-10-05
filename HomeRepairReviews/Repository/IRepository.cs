using HomeRepairReviews.Models;

namespace HomeRepairReviews.Repositories;

public interface IRepository
{
    Task<List<Feedback>> GetAllAsync();

Task<Feedback?> GetByIdAsync(int id);

    Task AddAsync(Feedback feedback);

    Task SaveChangesAsync();

    void Delete(Feedback feedback);
}
