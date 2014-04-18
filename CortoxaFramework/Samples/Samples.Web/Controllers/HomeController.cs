using System.Web.Mvc;
using Cortoxa.Common.Log;

namespace Samples.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger logger;

        public HomeController(ILogger logger)
        {
            this.logger = logger;
        }

        public ActionResult Index()
        {
            logger.Info("Hello Home Page!");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}