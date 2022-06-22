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
    public class LOG_LIBROController : Controller
    {
        private DS2_BIBLIOTECAEntities db = new DS2_BIBLIOTECAEntities();

        // GET: LOG_LIBRO
        public ActionResult Index()
        {
            var lOG_LIBRO = db.LOG_LIBRO.Include(l => l.LIBRO).Include(l => l.USUARIO);
            return View(lOG_LIBRO.ToList());
        }

        // GET: LOG_LIBRO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOG_LIBRO lOG_LIBRO = db.LOG_LIBRO.Find(id);
            if (lOG_LIBRO == null)
            {
                return HttpNotFound();
            }
            return View(lOG_LIBRO);
        }

        // GET: LOG_LIBRO/Create
        public ActionResult Create()
        {
            ViewBag.IDD_LIBRO = new SelectList(db.LIBRO, "IDD_LIBRO", "NOM_LIBRO");
            ViewBag.IDD_USUAR = new SelectList(db.USUARIO, "IDD_USUAR", "NOM_USUAR");
            return View();
        }

        // POST: LOG_LIBRO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDD_LOG_LIBRO,IDD_LIBRO,IDD_USUAR")] LOG_LIBRO lOG_LIBRO)
        {
            if (ModelState.IsValid)
            {
                db.LOG_LIBRO.Add(lOG_LIBRO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDD_LIBRO = new SelectList(db.LIBRO, "IDD_LIBRO", "NOM_LIBRO", lOG_LIBRO.IDD_LIBRO);
            ViewBag.IDD_USUAR = new SelectList(db.USUARIO, "IDD_USUAR", "NOM_USUAR", lOG_LIBRO.IDD_USUAR);
            return View(lOG_LIBRO);
        }

        // GET: LOG_LIBRO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOG_LIBRO lOG_LIBRO = db.LOG_LIBRO.Find(id);
            if (lOG_LIBRO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDD_LIBRO = new SelectList(db.LIBRO, "IDD_LIBRO", "NOM_LIBRO", lOG_LIBRO.IDD_LIBRO);
            ViewBag.IDD_USUAR = new SelectList(db.USUARIO, "IDD_USUAR", "NOM_USUAR", lOG_LIBRO.IDD_USUAR);
            return View(lOG_LIBRO);
        }

        // POST: LOG_LIBRO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDD_LOG_LIBRO,IDD_LIBRO,IDD_USUAR")] LOG_LIBRO lOG_LIBRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOG_LIBRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDD_LIBRO = new SelectList(db.LIBRO, "IDD_LIBRO", "NOM_LIBRO", lOG_LIBRO.IDD_LIBRO);
            ViewBag.IDD_USUAR = new SelectList(db.USUARIO, "IDD_USUAR", "NOM_USUAR", lOG_LIBRO.IDD_USUAR);
            return View(lOG_LIBRO);
        }

        // GET: LOG_LIBRO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOG_LIBRO lOG_LIBRO = db.LOG_LIBRO.Find(id);
            if (lOG_LIBRO == null)
            {
                return HttpNotFound();
            }
            return View(lOG_LIBRO);
        }

        // POST: LOG_LIBRO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOG_LIBRO lOG_LIBRO = db.LOG_LIBRO.Find(id);
            db.LOG_LIBRO.Remove(lOG_LIBRO);
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
