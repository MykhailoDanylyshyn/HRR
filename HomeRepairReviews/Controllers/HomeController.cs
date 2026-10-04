using HomeRepairReviews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeRepairReviews.Controllers;

public class HomeController : Controller
{
    private readonly FeedbackContext context;

    public HomeController(FeedbackContext context)
    {
        this.context = context;
    }

    public async Task<IActionResult> Index()
    {
        var feedbacks = await context.Feedbacks
            .Include(f => f.Photos)
            .OrderByDescending(f => f.Date)
            .ToListAsync();

        return View(feedbacks);
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}
