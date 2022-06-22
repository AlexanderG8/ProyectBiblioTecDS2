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
    public class RUTA_LIBROController : Controller
    {
        private DS2_BIBLIOTECAEntities db = new DS2_BIBLIOTECAEntities();

        // GET: RUTA_LIBRO
        public ActionResult Index()
        {
            return View(db.RUTA_LIBRO.ToList());
        }

        // GET: RUTA_LIBRO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RUTA_LIBRO rUTA_LIBRO = db.RUTA_LIBRO.Find(id);
            if (rUTA_LIBRO == null)
            {
                return HttpNotFound();
            }
            return View(rUTA_LIBRO);
        }

        // GET: RUTA_LIBRO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RUTA_LIBRO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDD_RUTA_LIBRO,NOM_RUTA,NOM_ARCHI,NOM_ARCHI_FISIC,IDD_LIBRO")] RUTA_LIBRO rUTA_LIBRO)
        {
            if (ModelState.IsValid)
            {
                db.RUTA_LIBRO.Add(rUTA_LIBRO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rUTA_LIBRO);
        }

        // GET: RUTA_LIBRO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RUTA_LIBRO rUTA_LIBRO = db.RUTA_LIBRO.Find(id);
            if (rUTA_LIBRO == null)
            {
                return HttpNotFound();
            }
            return View(rUTA_LIBRO);
        }

        // POST: RUTA_LIBRO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDD_RUTA_LIBRO,NOM_RUTA,NOM_ARCHI,NOM_ARCHI_FISIC,IDD_LIBRO")] RUTA_LIBRO rUTA_LIBRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rUTA_LIBRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rUTA_LIBRO);
        }

        // GET: RUTA_LIBRO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RUTA_LIBRO rUTA_LIBRO = db.RUTA_LIBRO.Find(id);
            if (rUTA_LIBRO == null)
            {
                return HttpNotFound();
            }
            return View(rUTA_LIBRO);
        }

        // POST: RUTA_LIBRO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RUTA_LIBRO rUTA_LIBRO = db.RUTA_LIBRO.Find(id);
            db.RUTA_LIBRO.Remove(rUTA_LIBRO);
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
    }
}
