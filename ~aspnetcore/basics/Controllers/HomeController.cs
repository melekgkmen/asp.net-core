using basics.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace basics.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View(Repository.Courses);
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}