using Microsoft.AspNetCore.Mvc;
using _7CWin.Models;
using System.Diagnostics;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _7CWin.Controllers
{
    public class HomeController : Controller
    {
        // GET: /
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/Error ?
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
