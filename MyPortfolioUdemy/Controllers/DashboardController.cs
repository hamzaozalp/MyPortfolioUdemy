using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.Controllers
{
    public class DashboardController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        //buradan ekleniyor
        public IActionResult Index()
        {
            ViewBag.MessageCount = context.Messages.Count();
            ViewBag.adminCount = context.TblAdmin.Count();
            ViewBag.skillCount = context.Skills.Count();
            ViewBag.ExperienceCount=context.Experiences.Count();
            //buraya veri girmen lazım
            return View();
        }
    }
}
