using HomeRepairReviews.Models;
using HomeRepairReviews.Repositories;
using HomeRepairReviews.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

string? UsersDBconnection = builder.Configuration.GetConnectionString("UsersDBconnection");
string? FeedbackDBconnection = builder.Configuration.GetConnectionString("FeedbackDBconnection");

builder.Services.AddDbContext<UserContext>(options => options.UseSqlServer(UsersDBconnection));
builder.Services.AddDbContext<FeedbackContext>(options => options.UseSqlServer(FeedbackDBconnection));

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IRepository, FeedbackRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseSession();
app.UseStaticFiles(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();