using System.Web.Mvc;

namespace SimpleCalendar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Title = "About Page";

            return View();
        }

    }
}
