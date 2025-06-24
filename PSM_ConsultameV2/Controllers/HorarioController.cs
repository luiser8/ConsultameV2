using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PSM_ConsultameV2.Controllers
{
    public class HorarioController : Controller
    {
        private readonly DAL.DALrecordHA recordsHa = new DAL.DALrecordHA();

        // GET: Horario
        public ActionResult Index()
        {
            if (Session["Alumno"] != null)
            {
                //alumno.GetRecords(Convert.ToInt32(Session["IdAl"]))
                return View();
            }
            return RedirectToAction("Index", "Account");
        }

        public JsonResult ObtenerHorario()
        {
            var datos = recordsHa.GetRecords(Convert.ToInt32(Session["IdAl"]));

            // Ordenamos por hora y día
            var ordenados = datos
                .OrderBy(h => DateTime.ParseExact(h.Hora, "hh:mm tt", System.Globalization.CultureInfo.InvariantCulture))
                .ThenBy(h => h.Dia)
                .ToList();

            return Json(ordenados, JsonRequestBehavior.AllowGet);
        }
    }
}