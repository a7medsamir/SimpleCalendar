using System.Web.Mvc;

namespace SimpleCalendar.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }
    }
}