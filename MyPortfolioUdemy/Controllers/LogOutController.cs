using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.Controllers
{
    public class LogOutController : Controller
    {
        public class LoginController : Controller
        {
            MyPortfolioContext context = new MyPortfolioContext();

            public class Admin
            {
                public string Username { get; set; }
                public string Password { get; set; }
            }

            [HttpGet]
            public ActionResult Index()
            {
                return View();
            }

            [HttpPost]
            [HttpPost]
            public IActionResult UpdateAdmin(Admin updatedAdmin)
            {
                var admin = context.TblAdmin.FirstOrDefault(x => x.Username == updatedAdmin.Username);
                if (admin != null)
                {
                    admin.Password = updatedAdmin.Password; 
                    context.SaveChanges(); 
                }
                return RedirectToAction("Index");
            }

        }
    }
}
