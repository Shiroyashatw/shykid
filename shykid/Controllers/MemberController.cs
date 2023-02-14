using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shykid.Data;
using shykid.Models;
using System.Security.Claims;


namespace shykid.Controllers
{
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MemberController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Singup()
        {
            return View();
        }

        public IActionResult Singupok()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Singup(Member obj)
        {
            if(ModelState.IsValid)
            {
                _db.Members.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "註冊成功";
                return RedirectToAction("Singupok","Member",null);
            }
            return View(obj);
        }

        public IActionResult Login(string returnUrl) 
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequest request) 
        {
            // 判斷帳號密碼的正確性
            if(await _db.Members.AnyAsync(a=>a.Account==request.Account && a.Password==request.Password))
            {
                // 登錄授權
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,request.Account)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // 它會自動發送 token給客戶端 ,並產生cookies
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        // cookies 保持登入時間
                        IsPersistent = true,
                    }
                    );
            }
            else
            {
                return RedirectToAction(nameof(Login));
            }
            return Redirect(request.ReturnUrl??"/");
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        public class UserLoginRequest : Member
        {
            public string ReturnUrl { get; set; }
        }
    }
}
