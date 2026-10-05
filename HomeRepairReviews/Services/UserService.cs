using HomeRepairReviews.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeRepairReviews.Services;

public class UserService
{
    private readonly UserContext context;

public UserService(UserContext context)
    {
        this.context = context;
    }

    public async Task<User?> GetByLoginAsync(string login)
    {
        return await context.Users
            .FirstOrDefaultAsync(u => u.Login == login);
    }

    public async Task<bool> LoginExistsAsync(string login)
    {
        return await context.Users
            .AnyAsync(u => u.Login == login);
    }

    public async Task AddAsync(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
    }

}
