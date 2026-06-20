using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementMVC.Models;
using TaskManagementMVC.Data;

namespace TaskManagementMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(
                    u => u.Name == model.Username
                      && u.Password == model.Password);

                if (user != null)
                {
                    HttpContext.Session.SetString(
                        "User",
                        user.Name);

                    return RedirectToAction(
                        "Index",
                        "TaskItems");
                }

                ViewBag.Error =
                    "Invalid username or password.";
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(
                "Index",
                "TaskItems");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(
        RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser =
                    _context.Users.FirstOrDefault(
                        u => u.Email == model.Email);

                if (existingUser != null)
                {
                    ViewBag.Error =
                        "User with this email already exists.";

                    return View(model);
                }

                var user = new User
                {
                    Name = model.Username,
                    Email = model.Email,
                    Password = model.Password
                };

                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                HttpContext.Session.SetString(
                    "User",
                    user.Name);

                return RedirectToAction(
                    "Index",
                    "TaskItems");
            }

            return View(model);
        }
        private readonly ApplicationDbContext _context;

        public AccountController(
            ApplicationDbContext context)
        {
            _context = context;
        }
    }
}