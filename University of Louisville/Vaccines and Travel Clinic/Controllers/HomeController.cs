using System.Web.Mvc;


namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Research()
        {
            ViewBag.Message = "Your research page.";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Your services page.";

            return View();
        }

        public ActionResult Immunization()
        {
            ViewBag.Message = "Your immunization page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your about page.";

            return View();
        }

        public ActionResult Surgeon()
        {
            ViewBag.Message = "Your civil surgeon page.";

            return View();
        }

        public ActionResult Partners()
        {
            ViewBag.Message = "Your partners page.";

            return View();
        }

        public ActionResult Repository()
        {
            ViewBag.Message = "Your repository page.";

            return View();
        }
        
        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your dashboard page.";

            return View();
        }
    }
}
