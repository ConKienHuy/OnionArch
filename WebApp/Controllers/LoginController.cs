using System.Security.Claims;
using Application.Interfaces;
using Core.Entites;
using Core.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace OnionArc.Controllers;

[Controller]
public class LoginController : Controller
{
    private readonly ILoginService userService;

    public LoginController(ILoginService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    [Route("/login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [Route("/login")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(User user)
    {
        if (userService.Login(user.UserName, user.UserPassword))
        {
            var userName = HttpContext.Session.GetString("UserName");

            //ModelState.AddModelError("", "Invalid username or password");
            //return View(user);

            // Tạo Claims cho người dùng
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName)
            };

            // Tạo ClaimsIdentity
            var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuth");
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Invalid username or password");
        return View(user);
    }

    [HttpGet]
    [Route("/register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [Route("/register")]
    [ValidateAntiForgeryToken]
    public IActionResult Register(User user)
    {
        if (!ModelState.IsValid)
            return View(user);

        HttpContext.Session.SetString("UserName", user.UserName);
        user.UserStatus = (int)EStatus.Active;
        var newUser = userService.Register(user);
        if (newUser != null) return RedirectToAction("Index", "Home");
        ModelState.AddModelError("", "Something Happened");
        return View(user);
    }

    [HttpPost]
    [Route("/logout")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        // Xóa cookie xác thực
        await HttpContext.SignOutAsync("MyCookieAuth");

        // Xóa session nếu có sử dụng
        HttpContext.Session.Clear();

        // Điều hướng về trang đăng nhập hoặc trang chủ
        return RedirectToAction("Login", "Login");
    }
}