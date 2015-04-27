using System.Web.Mvc;

namespace NancyWithTokenAuthentication.Web.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        [Authorize]
        public ActionResult Index()
        {
            return File("index.html", "text/html"); 
        }
    }
}