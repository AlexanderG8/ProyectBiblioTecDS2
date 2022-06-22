using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using waBiblioteca;

namespace waBiblioteca.Controllers
{
    public class USUARIOController : Controller
    {
        private DS2_BIBLIOTECAEntities db = new DS2_BIBLIOTECAEntities();

        // GET: USUARIO
        public ActionResult Index(string nombre)
        {
            var uSUARIO = new List<USUARIO>();
            if (nombre == null || nombre == "")
            {
                uSUARIO = db.USUARIO.Include(u => u.ROL).ToList();
            }
            else
            {
                uSUARIO = db.USUARIO.Include(u => u.ROL).Where(z => z.NOM_USUAR.Contains(nombre) || z.APE_USUAR.Contains(nombre) || z.NOM_CORRE.Contains(nombre)).ToList();
            }
            return View(uSUARIO);
        }

        // GET: USUARIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // GET: USUARIO/Create
        public ActionResult Create()
        {
            ViewBag.IDD_ROL = new SelectList(db.ROL, "IDD_ROL", "DESCRIPCION");
            return View();
        }

        // POST: USUARIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDD_USUAR,NOM_USUAR,APE_USUAR,TIP_DOCUM,NUM_DOCUM,NOM_CORRE,DES_CONTR,IDD_ROL")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO.Add(uSUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDD_ROL = new SelectList(db.ROL, "IDD_ROL", "DESCRIPCION", uSUARIO.IDD_ROL);
            return View(uSUARIO);
        }

        // GET: USUARIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDD_ROL = new SelectList(db.ROL, "IDD_ROL", "DESCRIPCION", uSUARIO.IDD_ROL);
            return View(uSUARIO);
        }

        // POST: USUARIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDD_USUAR,NOM_USUAR,APE_USUAR,TIP_DOCUM,NUM_DOCUM,NOM_CORRE,DES_CONTR,IDD_ROL")] USUARIO uSUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDD_ROL = new SelectList(db.ROL, "IDD_ROL", "DESCRIPCION", uSUARIO.IDD_ROL);
            return View(uSUARIO);
        }

        // GET: USUARIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USUARIO uSUARIO = db.USUARIO.Find(id);
            if (uSUARIO == null)
            {
                return HttpNotFound();
            }
            return View(uSUARIO);
        }

        // POST: USUARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USUARIO uSUARIO = db.USUARIO.Find(id);
            db.USUARIO.Remove(uSUARIO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Login(string username, string password) 
        {
            var login = db.USUARIO.Where(z => z.NOM_CORRE.Equals(username) && z.DES_CONTR.Equals(password)).FirstOrDefault();

            ViewBag.Mensaje = "";
            if (login == null) 
            {
                ViewBag.Mensaje = "Usuario no existe";
            }
            return RedirectToAction("Index");
        }
    }
}
