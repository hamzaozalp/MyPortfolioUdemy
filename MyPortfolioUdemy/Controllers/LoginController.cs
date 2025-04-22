using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.Models;
using System.Security.Claims;

namespace MyPortfolioUdemy.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Login/Index
        [HttpGet]
        public IActionResult Index(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // POST: /Login/Index
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF saldırılarına karşı koruma
        public async Task<IActionResult> Index(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                
                if (model.Username.ToLower() == "admin" && model.Password == "12345") // Kullanıcı adı ve şifreyi burada belirleyin
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username),
                      
                    };

                    //bundan sonrası basit bu yazıları yapay zeka mı yazıyor sen cursor mu kullanıyorsun
                    //claude 3.7 kullanıyorum açıkla diyorum yazdığın kodu o yazıyor ama şimdiki işlemleri ben yaptım
                    var authProperties = new AuthenticationProperties
                    {
                        
                        RedirectUri = returnUrl ?? Url.Action("AboutList", "About") // Giriş sonrası varsayılan yönlendirme (Örn: About sayfası)
                    };

                   

                    
                    return Redirect(authProperties.RedirectUri); 
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Geçersiz kullanıcı adı veya şifre.");
                    return View(model);
                }
                
            }

           
            return View(model);
        }

        // GET: /Login/Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            // Kullanıcıyı sistemden çıkar (Cookie silinir)
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login"); // Login sayfasına yönlendir
        }

        // GET: /Login/AccessDenied
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View(); // Yetkisiz erişim sayfasını göster
        }
    }
}

