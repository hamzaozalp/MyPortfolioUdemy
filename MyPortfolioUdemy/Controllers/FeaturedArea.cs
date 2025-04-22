using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioUdemy.Controllers
{
    public class FeaturedArea : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Öne Çıkan Alanıma Hoşgeldiniz!";
            ViewBag.Description = "Burası özel bi alan ve keşfetmeniz için burada.";
            ViewBag.Date = DateTime.Now.ToString("MMMM dd, yyyy");
            ViewBag.Time = DateTime.Now.ToString("hh:mm tt");
            ViewBag.UserName = "Abdullah Ördek "; // Example user name
            ViewBag.UserRole = "Admin42"; // Example user role

            return View();
        }
    }
}
