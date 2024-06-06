using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Papeleriaweb.Models;
using Papeleriaweb.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Security.Claims;

namespace Papeleriaweb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var usuario = _context.Usuario.SingleOrDefault(u => u.Username == username && u.Password == password);
            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Username),
                    new Claim("UserType", usuario.UserType) // Añadir el tipo de usuario como un Claim
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties { IsPersistent = true };

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties).Wait();

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Credenciales inválidas";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult Register(string name)
        {
            ViewBag.Name = name;
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string confirmPassword, string userType, string name)
        {
            if (password != confirmPassword)
            {
                ViewBag.Message = "Las contraseñas no coinciden";
                ViewBag.Name = name;
                return View();
            }

            var existingUser = _context.Usuario.SingleOrDefault(u => u.Username == username);
            if (existingUser != null)
            {
                ViewBag.Message = "El nombre de usuario ya existe";
                ViewBag.Name = name;
                return View();
            }

            var newUser = new Usuario
            {
                Name = name, // Asumiendo que tienes un campo Name en tu modelo Usuario
                Username = username,
                Password = password,
                UserType = userType, // Asumiendo que tienes un campo UserType en tu modelo Usuario

            };

            _context.Usuario.Add(newUser);
            _context.SaveChanges();

            ViewBag.Message = "Registro exitoso. Ahora puedes iniciar sesión.";
            return View("Login");
        }

    }
}
