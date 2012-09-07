using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarea1.Models;

namespace Tarea1.Controllers
{
    public class RegistroGuardiaController : Controller
    {
        private Tarea1DbContext db = new Tarea1DbContext();

        //
        // GET: /RegistroGuardia/

        public ActionResult Index()
        {
            var registroguardias = db.RegistroGuardias.Include(r => r.Integrante);
            return View(registroguardias.ToList());
        }

        //
        // GET: /RegistroGuardia/Details/5

        public ActionResult Details(int id = 0)
        {
            RegistroGuardia registroguardia = db.RegistroGuardias.Find(id);
            if (registroguardia == null)
            {
                return HttpNotFound();
            }
            return View(registroguardia);
        }

        //
        // GET: /RegistroGuardia/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.IntegranteId = new SelectList(db.Integrantes, "IntegranteId", "Nombre");
            return View();
        }

        //
        // POST: /RegistroGuardia/Create
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult Create(RegistroGuardia registroguardia)
        {
            if (ModelState.IsValid)
            {
                db.RegistroGuardias.Add(registroguardia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IntegranteId = new SelectList(db.Integrantes, "IntegranteId", "Nombre", registroguardia.IntegranteId);
            return View(registroguardia);
        }

        //
        // GET: /RegistroGuardia/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int id = 0)
        {
            RegistroGuardia registroguardia = db.RegistroGuardias.Find(id);
            if (registroguardia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IntegranteId = new SelectList(db.Integrantes, "IntegranteId", "Nombre", registroguardia.IntegranteId);
            return View(registroguardia);
        }

        //
        // POST: /RegistroGuardia/Edit/5
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult Edit(RegistroGuardia registroguardia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroguardia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IntegranteId = new SelectList(db.Integrantes, "IntegranteId", "Nombre", registroguardia.IntegranteId);
            return View(registroguardia);
        }

        //
        // GET: /RegistroGuardia/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int id = 0)
        {
            RegistroGuardia registroguardia = db.RegistroGuardias.Find(id);
            if (registroguardia == null)
            {
                return HttpNotFound();
            }
            return View(registroguardia);
        }

        //
        // POST: /RegistroGuardia/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroGuardia registroguardia = db.RegistroGuardias.Find(id);
            db.RegistroGuardias.Remove(registroguardia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Actual()
        {
            List<Integrante> voluntariosEnGuardia = db.ObtenerVoluntariosEnGuardia();
            ViewBag.IntegranteQueManda = Integrante.ObtenerCargoMasAlto(voluntariosEnGuardia);
            ViewBag.Voluntarios = voluntariosEnGuardia;
            return View();
        }

    }
}