using HomeRepairReviews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeRepairReviews.Controllers;

public class FeedbackController(
    FeedbackContext context,
    IWebHostEnvironment appEnvironment) : Controller
{
    // GET: Feedback
    public async Task<IActionResult> Index()
    {
        var feedbacks = await context.Feedbacks
            .Include(f => f.Photos)
            .OrderByDescending(f => f.Date)
            .ToListAsync();

        return View(feedbacks);
    }

    // GET: Feedback/Create
    public IActionResult Create()
    {
        if (HttpContext.Session.GetString("Login") == null)
            return RedirectToAction("Login", "Account");

        return View();
    }

    // POST: Feedback/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [RequestSizeLimit(100_000_000)]
    public async Task<IActionResult> Create(
        [Bind("Master,WorkType,Text")] Feedback feedback,
        List<IFormFile>? photoFiles)
    {
        var login = HttpContext.Session.GetString("Login");

        if (login == null)
            return RedirectToAction("Login", "Account");

        feedback.UserName =
            HttpContext.Session.GetString("FirstName") ?? login;

        feedback.Date = DateTime.Now;

        ModelState.Remove(nameof(Feedback.UserName));

        if (!ModelState.IsValid)
            return View(feedback);

        if (photoFiles != null)
        {
            var photosPath = Path.Combine(
                appEnvironment.WebRootPath,
                "feedback");

            Directory.CreateDirectory(photosPath);

            foreach (var photoFile in photoFiles)
            {
                if (photoFile.Length == 0)
                    continue;

                var extension = Path.GetExtension(photoFile.FileName);
                var fileName = $"{Guid.NewGuid()}{extension}";

                var absolutePath = Path.Combine(
                    photosPath,
                    fileName);

                var relativePath = $"/feedback/{fileName}";

                await using var fileStream = new FileStream(
                    absolutePath,
                    FileMode.Create);

                await photoFile.CopyToAsync(fileStream);

                feedback.Photos.Add(new FeedbackPhoto
                {
                    PhotoPath = relativePath
                });
            }
        }

        context.Feedbacks.Add(feedback);

        await context.SaveChangesAsync();

        return RedirectToAction("Index", "Home");
    }

    // GET: Feedback/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var feedback = await context.Feedbacks
            .Include(f => f.Photos)
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == id);

        if (feedback == null)
            return NotFound();

        return View(feedback);
    }
// GET: Feedback/Edit/5
public async Task<IActionResult> Edit(int? id)
    {
        if (HttpContext.Session.GetString("Login") != "admin")
            return Forbid();

        if (id == null)
            return NotFound();

        var feedback = await context.Feedbacks
            .Include(f => f.Photos)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (feedback == null)
            return NotFound();

        return View(feedback);
    }

    // POST: Feedback/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [RequestSizeLimit(100_000_000)]
    public async Task<IActionResult> Edit(
    int id,
    string master,
    string workType,
    string text,
    List<int>? deletePhotoIds,
    List<IFormFile>? photoFiles)
    {
        if (HttpContext.Session.GetString("Login") != "admin")
            return Forbid();

        var feedback = await context.Feedbacks
            .Include(f => f.Photos)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (feedback == null)
            return NotFound();

        if (string.IsNullOrWhiteSpace(text))
        {
            ModelState.AddModelError("text", "Введіть текст відгуку.");

            return View(feedback);
        }

        feedback.Text = text;

        // Видалення вибраних фото
        if (deletePhotoIds != null)
        {
            foreach (var photoId in deletePhotoIds)
            {
                var photo = feedback.Photos
                    .FirstOrDefault(p => p.Id == photoId);

                if (photo != null)
                {
                    var filePath = Path.Combine(
                        appEnvironment.WebRootPath,
                        photo.PhotoPath
                            .TrimStart('/')
                            .Replace('/', Path.DirectorySeparatorChar));

                    if (System.IO.File.Exists(filePath))
                        System.IO.File.Delete(filePath);

                    context.FeedbackPhotos.Remove(photo);
                }
            }
        }

        // Додавання нових фото
        if (photoFiles != null)
        {
            var photosPath = Path.Combine(
                appEnvironment.WebRootPath,
                "feedback");

            Directory.CreateDirectory(photosPath);

            foreach (var photoFile in photoFiles)
            {
                if (photoFile.Length == 0)
                    continue;

                var extension = Path.GetExtension(photoFile.FileName);
                var fileName = $"{Guid.NewGuid()}{extension}";

                var absolutePath = Path.Combine(
                    photosPath,
                    fileName);

                var relativePath = $"/feedback/{fileName}";

                await using var fileStream = new FileStream(
                    absolutePath,
                    FileMode.Create);

                await photoFile.CopyToAsync(fileStream);

                feedback.Photos.Add(new FeedbackPhoto
                {
                    PhotoPath = relativePath
                });
            }
        }

        await context.SaveChangesAsync();

        return RedirectToAction("Index", "Home");
    }


    // GET: Feedback/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (HttpContext.Session.GetString("Login") != "admin")
            return Forbid();

        if (id == null)
            return NotFound();

        var feedback = await context.Feedbacks
            .Include(f => f.Photos)
            .AsNoTracking()
            .FirstOrDefaultAsync(f => f.Id == id);

        if (feedback == null)
            return NotFound();

        return View(feedback);
    }

    // POST: Feedback/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (HttpContext.Session.GetString("Login") != "admin")
            return Forbid();

        var feedback = await context.Feedbacks
            .Include(f => f.Photos)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (feedback != null)
        {
            foreach (var photo in feedback.Photos)
            {
                var photoPath = Path.Combine(
                    appEnvironment.WebRootPath,
                    photo.PhotoPath
                        .TrimStart('/')
                        .Replace('/', Path.DirectorySeparatorChar));

                if (System.IO.File.Exists(photoPath))
                    System.IO.File.Delete(photoPath);
            }

            context.Feedbacks.Remove(feedback);

            await context.SaveChangesAsync();
        }

        return RedirectToAction("Index", "Home");
    }
}
