using Microsoft.AspNetCore.Mvc;
using HomeRepairReviews.Models;
using HomeRepairReviews.Services;
using System.Security.Cryptography;
using System.Text;

namespace HomeRepairReviews.Controllers;

public class AccountController(UserService userService) : Controller
{
    public IActionResult Login() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel logon)
    {
        if (!ModelState.IsValid)
            return View(logon);

        var user = await userService.GetByLoginAsync(logon.Login);

        if (user == null)
        {
            ModelState.AddModelError(
                string.Empty,
                "Невірний логін або пароль!");

            return View(logon);
        }

        byte[] passwordBytes =
            Encoding.Unicode.GetBytes(user.Salt + logon.Password);

        string hash =
            Convert.ToHexString(SHA256.HashData(passwordBytes));

        if (user.Password != hash)
        {
            ModelState.AddModelError(
                string.Empty,
                "Невірний логін або пароль!");

            return View(logon);
        }

        HttpContext.Session.SetString("Login", user.Login!);
        HttpContext.Session.SetString("FirstName", user.FirstName!);
        HttpContext.Session.SetString("LastName", user.LastName!);

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Register() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterModel reg)
    {
        if (!ModelState.IsValid)
            return View(reg);

        if (await userService.LoginExistsAsync(reg.Login))
        {
            ModelState.AddModelError(
                string.Empty,
                "Користувач з таким логіном вже існує!");

            return View(reg);
        }

        byte[] saltBytes = RandomNumberGenerator.GetBytes(16);
        string salt = Convert.ToHexString(saltBytes);

        byte[] passwordBytes =
            Encoding.Unicode.GetBytes(salt + reg.Password);

        string hash =
            Convert.ToHexString(SHA256.HashData(passwordBytes));

        var user = new User
        {
            FirstName = reg.FirstName,
            LastName = reg.LastName,
            Login = reg.Login,
            Salt = salt,
            Password = hash
        };

        await userService.AddAsync(user);

        return RedirectToAction(nameof(Login));
    }
}
