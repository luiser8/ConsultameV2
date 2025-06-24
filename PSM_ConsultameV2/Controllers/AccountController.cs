using PSM_ConsultameV2.Models;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace PSM_ConsultameV2.Controllers
{
    ///<summary>
    ///Clase Account para crear los acceso al sistema mediante sesiones
    ///<return>
    ///Metodo Index deveulve la vista principal para autenticarse
    ///Metodo Login crea la sesion y verifica la existencia del usuario
    ///Metodo Logout cerrar la sesion
    ///</return>
    ///</summary>
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            if (Session["Alumno"] != null)
            {
                return RedirectToAction("Index", "DatosAcademicos");
            }

            ViewBag.Institucion = ConfigurationManager.AppSettings["Institucion"].ToString();
            return View();
        }

        #region Login
        
        [HttpPost]
        public ActionResult Login(Account account)
        {
            DAL.DALrecordDA alumno = new DAL.DALrecordDA();
            alumno.GetRecords(account.Cedula);

            var Cedula = account.Cedula;
            var Clave = account.Password;

            if (ModelState.IsValid)
            {
                try
                {
                    var alumnoRecord = alumno.GetRecords(account.Cedula);
                    if (alumnoRecord.Count() > 0)
                    {
                        if (Cedula.Substring(0,5) == Clave)
                        {
                            string FullNombre = alumno.GetRecords(account.Cedula).First().FullNombre;
                            int IdAl = alumno.GetRecords(account.Cedula).First().IdAl;

                            if (alumno.GetRecords(account.Cedula).First().Foto.Length > 4)
                            {
                                var Foto = Convert.ToBase64String(alumno.GetRecords(account.Cedula).First().Foto);
                                var imgSrc = String.Format("data:image/png;base64,{0}", Foto);
                                Session["Foto"] = imgSrc;
                            }
                            else
                            {
                                switch (alumno.GetRecords(account.Cedula).First().Sexo)
                                {
                                    case 0:
                                        Session["Foto"] = "/Images/boy.png";
                                        break;
                                    case 1:
                                        Session["Foto"] = "/Images/girl.png";
                                        break;
                                }
                            }

                            Session["Alumno"] = FullNombre;
                            Session["IdAl"] = IdAl;
                            Session["Cedula"] = Cedula;

                            return RedirectToAction("Index", "DatosAcademicos");
                        }
                    }
                }
                catch (Exception ex)
                {
                    return View(ex.Message.ToString());
                }
            }
            else
            {
                return RedirectToAction("Index", "Account");
            }

            return RedirectToAction("Index", "Account");
        }

        #endregion
        #region Logout
        [HttpGet]
        public ActionResult Logout()
        {
            Session["Alumno"] = null;
            Session["IdAl"] = null;
            return RedirectToAction("Index", "Account");
        }
        #endregion
    }
}