using System;
using System.Web.Mvc;

namespace PSM_ConsultameV2.Controllers
{
    public class CalificacionesController : Controller
    {
        // GET: Calificaciones
        public ActionResult Index()
        {
            if (Session["Alumno"] != null)
            {
                DAL.DALrecordNA alumno = new DAL.DALrecordNA();
                return View(alumno.GetRecords(Convert.ToInt32(Session["IdAl"])));
            }
            return RedirectToAction("Index", "Account");
        }
    }
}