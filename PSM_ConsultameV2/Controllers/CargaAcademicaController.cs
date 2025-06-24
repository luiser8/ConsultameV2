using System;
using System.Web.Mvc;

namespace PSM_ConsultameV2.Controllers
{
    public class CargaAcademicaController : Controller
    {
        // GET: CargaAcademica
        public ActionResult Index()
        {
            if (Session["Alumno"] != null)
            {
                DAL.DALrecordCA alumno = new DAL.DALrecordCA();
                return View(alumno.GetRecords(Convert.ToInt32(Session["IdAl"])));
            }
            return RedirectToAction("Index", "Account");
        }
    }
}