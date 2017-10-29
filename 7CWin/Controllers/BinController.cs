using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _7CWin.Models;

namespace _7CWin.Controllers
{
    public class BinController : Controller
    {
        public _7cwinContext Db;
        public BinController(_7cwinContext db)
        {
            Db = db;
        }

        // GET: /bin/:id
        [HttpGet("/bin/{id}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
