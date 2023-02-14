using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shykid.Models;
using System.Diagnostics;

namespace shykid.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // 首頁 index
        public IActionResult Index()
        {
            return View();
        }
        // 領養頁面
        public IActionResult Adoption()
        {
            return View();
        }

        // 領養頁面 內部頁面
        public IActionResult Adoptionpage01()
        {
            return View();
        }

        public IActionResult Adoptionpage02()
        {
            return View();
        }
        public IActionResult Adoptionpage03()
        {
            return View();
        }
        public IActionResult Adoptionpage04()
        {
            return View();
        }

        public IActionResult Adoptionpage05()
        {
            return View();
        }
        public IActionResult Adoptionpage06()
        {
            return View();
        }
        public IActionResult Adoptionpage07()
        {
            return View();
        }
        public IActionResult Adoptionpage08()
        {
            return View();
        }
        // 疫苗知識頁面 
        public IActionResult Vaccine()
        {
            return View();
        }

        // 常見症狀頁面
        public IActionResult Disease()
        {
            return View();
        }

        // 討論區頁面
        public IActionResult Forum()
        {
            return View();
        }

        // 討論區頁面 內部頁面
        public IActionResult Forum01()
        {
            return View();
        }

        // 專欄報導
        public IActionResult Column()
        {
            return View();
        }

        //關於我們
        public IActionResult Aboutus()
        {
            return View();
        }

        // 登入頁面
        //public IActionResult Login()
        //{
        //    return View();
        //}

        // 註冊頁面
        public IActionResult Singup()
        {
            return View();
        }

        // 忘記密碼
        public IActionResult Forget()
        {
            return View();
        }

        public IActionResult Ppt()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}