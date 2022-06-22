using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace waBiblioteca.Controllers
{
    public class LoginController : Controller
    {
        private DS2_BIBLIOTECAEntities db = new DS2_BIBLIOTECAEntities();

        // GET: Login
        public ActionResult Index(string mensaje)
        {
            mensaje = (mensaje == null) ? mensaje = "" : mensaje;
            ViewBag.Mensaje = mensaje;
            return View();
        }


        public ActionResult Logearse(string username, string password) 
        {
            var logeo = db.USUARIO.Where(z => z.NOM_CORRE.Equals(username) && z.DES_CONTR.Equals(password)).FirstOrDefault();
            var mensaje = "Usuario no existe";
            if (logeo != null && logeo.IDD_ROL.Equals(2)) 
            {
                mensaje = "";
                return RedirectToAction(nameof(PaginaPrincipal));
            }
            if (logeo != null && logeo.IDD_ROL.Equals(1))
            {
                mensaje = "";
                return RedirectToAction(nameof(Administrador));
            }
            return RedirectToAction("Index", new { mensaje = mensaje});
        }


        public ActionResult PaginaPrincipal() 
        {
            return View();
        }


        public ActionResult CerrarSesion() 
        {
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Administrador()
        {
            return View();
        }
       
    }
}
