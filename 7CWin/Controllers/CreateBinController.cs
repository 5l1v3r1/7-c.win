using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _7CWin.Models;

namespace _7CWin.Controllers
{
    public class CreateBinController : Controller
    {
        public _7cwinContext Db;

        public CreateBinController(_7cwinContext db)
        {
            Db = db;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // POST: /createbin
        [HttpPost("/createbin"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string ciphertext, string iv)
        {
            var requiredValue = (
                !string.IsNullOrWhiteSpace(ciphertext)
                && !string.IsNullOrWhiteSpace(iv)
                && iv.Length == 32
                );

            if (requiredValue)
            {
                var urlD = RandomString(12);

                var toInsert = new Bin
                {
                    Id = urlD,
                    Iv = iv,
                    Ciphertext = ciphertext
                };

                await Db.Bin.AddAsync(toInsert);
                await Db.SaveChangesAsync();

                return Ok(urlD);
            }
            return BadRequest();
        }
    }
}
