using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Papeleriaweb.Models;
using Papeleriaweb.Data;
using Microsoft.AspNetCore.Authorization;

namespace Papeleriaweb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Username = User.Identity.Name;
            }
            return View();
        }
    }
}

