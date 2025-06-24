using System;
using System.Web.Mvc;

namespace PSM_ConsultameV2.Controllers
{
    public class CortesController : Controller
    {
        // GET: Cortes
        public ActionResult Index()
        {
            if (Session["Alumno"] != null)
            {
                DAL.DALrecordCV alumno = new DAL.DALrecordCV();
                return View(alumno.GetRecords(Convert.ToInt32(Session["IdAl"])));
            }
            return RedirectToAction("Index", "Account");
        }
    }
}