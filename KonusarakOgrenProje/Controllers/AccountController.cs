using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KonusarakOgrenProje.Data;
using KonusarakOgrenProje.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;

namespace KonusarakOgren.Controllers
{
    public class AccountController : Controller
    {
        DataContext r = new DataContext();
        private readonly DataContext _context;

        public AccountController(ILogger<AccountController> logger,
                                       DataContext context)
        {
            _context = context;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(Users model)
        {
            var data = r.Users.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
            if (data != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.UserName)
                };
                var Useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(Useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("ExamList", "Exam");
            }
            else
            {
                ViewBag.Error = "Lütfen kullanıcı adınızı ve şifrenizi kontrol ediniz";
                return View();          
            }            
        }
    }
}

