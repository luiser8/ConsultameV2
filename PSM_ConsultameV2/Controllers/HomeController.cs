using System.Configuration;
using System.Web.Mvc;

namespace PSM_ConsultameV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Alumno"] != null)
            {
                ViewBag.Institucion = ConfigurationManager.AppSettings["Institucion"].ToString();
                return View();
            }
            return RedirectToAction("Index", "Account");
        }
    }
}