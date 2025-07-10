using System;
using System.Web.Mvc;

namespace PSM_ConsultameV2.Controllers
{
    public class MateriasController : Controller
    {
        // GET: Materias
        public ActionResult Index()
        {
            if (Session["Alumno"] != null)
            {
                DAL.DALrecordMV alumno = new DAL.DALrecordMV();
                return View(alumno.GetRecords(Convert.ToInt32(Session["IdAl"])));
            }
            return RedirectToAction("Index", "Account");
        }
    }
}