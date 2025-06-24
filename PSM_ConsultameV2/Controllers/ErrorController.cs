using System.Web.Mvc;

namespace PSM_ConsultameV2.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NotFound()
        {
            return View();
        }
    }
}