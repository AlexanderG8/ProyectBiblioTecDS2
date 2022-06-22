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
    public class LIBROController : Controller
    {
        private DS2_BIBLIOTECAEntities db = new DS2_BIBLIOTECAEntities();

        // GET: LIBRO
        public ActionResult Index(string nombre)
        {
            var lIBRO = new List<LIBRO>();
            if (nombre == null || nombre == "")
            {
                lIBRO = db.LIBRO.Include(l => l.CATEGORIA).ToList();
            }
            else
            {
                lIBRO = db.LIBRO.Include(l => l.CATEGORIA).Where(z => z.NOM_LIBRO.Contains(nombre) || z.NOM_AUTOR.Contains(nombre) || z.CATEGORIA.DESCRIPCION.Contains(nombre)).ToList();
            }
            return View(lIBRO);
        }

        // GET: LIBRO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIBRO lIBRO = db.LIBRO.Find(id);
            if (lIBRO == null)
            {
                return HttpNotFound();
            }
            return View(lIBRO);
        }

        // GET: LIBRO/Create
        public ActionResult Create()
        {
            ViewBag.IDD_CATER = new SelectList(db.CATEGORIA, "IDD_CATER", "DESCRIPCION");
            return View();
        }

        // POST: LIBRO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDD_LIBRO,NOM_LIBRO,NOM_EDITO,NOM_AUTOR,NOM_IDIOM,NUM_PAGIN,DES_RESUM,IDD_CATER")] LIBRO lIBRO)
        {
            if (ModelState.IsValid)
            {
                db.LIBRO.Add(lIBRO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDD_CATER = new SelectList(db.CATEGORIA, "IDD_CATER", "DESCRIPCION", lIBRO.IDD_CATER);
            return View(lIBRO);
        }

        // GET: LIBRO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIBRO lIBRO = db.LIBRO.Find(id);
            if (lIBRO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDD_CATER = new SelectList(db.CATEGORIA, "IDD_CATER", "DESCRIPCION", lIBRO.IDD_CATER);
            return View(lIBRO);
        }

        // POST: LIBRO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDD_LIBRO,NOM_LIBRO,NOM_EDITO,NOM_AUTOR,NOM_IDIOM,NUM_PAGIN,DES_RESUM,IDD_CATER")] LIBRO lIBRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lIBRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDD_CATER = new SelectList(db.CATEGORIA, "IDD_CATER", "DESCRIPCION", lIBRO.IDD_CATER);
            return View(lIBRO);
        }

        // GET: LIBRO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIBRO lIBRO = db.LIBRO.Find(id);
            if (lIBRO == null)
            {
                return HttpNotFound();
            }
            return View(lIBRO);
        }

        // POST: LIBRO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LIBRO lIBRO = db.LIBRO.Find(id);
            db.LIBRO.Remove(lIBRO);
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
