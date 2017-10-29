using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _7CWin.Models;
using Microsoft.EntityFrameworkCore;

namespace _7CWin.Controllers
{
    public class BinPController : Controller
    {
        public _7cwinContext Db;
        public BinPController(_7cwinContext db)
        {
            Db = db;
        }

        // GET: /:id.:mode
        [HttpGet("/{id}.{mode}")]
        public async Task<IActionResult> BinPage(string id, string mode)
        {
            var bin = await Db.Bin
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();

            if (bin != null)
            {
                return View(new BinIndexModel
                {
                    ciphertext = bin.Ciphertext,
                    iv = bin.Iv,
                    mode = mode.ToLower()
                });
            }
            return Redirect("/");
        }
        // GET: /:id.:mode
        [HttpGet("/{id}")]
        public async Task<IActionResult> BinNoMode(string id)
        {
            var bin = await Db.Bin
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();

            if (bin != null)
            {
                return View("~/Views/BinP/BinPage.cshtml", new BinIndexModel
                {
                    ciphertext = bin.Ciphertext,
                    iv = bin.Iv
                });
            }
            return Redirect("/");
        }
    }
}
