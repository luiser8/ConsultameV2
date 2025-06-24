using System;
using System.Web.Mvc;

namespace PSM_ConsultameV2.Controllers
{
    public class DatosAcademicosController : Controller
    {
        // GET: DatosAcademicos
        public ActionResult Index(/*(string Cedula*/)
        {
            if (Session["Alumno"] != null)
            {
                DAL.DALrecordDA alumno = new DAL.DALrecordDA();
                return View(alumno.GetRecords(Convert.ToString(Session["Cedula"])));
            }
            return RedirectToAction("Index", "Account");
        }
    }
}