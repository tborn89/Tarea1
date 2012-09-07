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
    public class IntegrantesController : Controller
    {
        private Tarea1DbContext db = new Tarea1DbContext();

        //
        // GET: /Integrantes/

        public ActionResult Index()
        {
            var integrantes = db.Integrantes.Include(i => i.Cargo);
            return View(integrantes.ToList());
        }

        //
        // GET: /Integrantes/Details/5

        public ActionResult Details(int id = 0)
        {
            Integrante integrante = db.Integrantes.Find(id);
            if (integrante == null)
            {
                return HttpNotFound();
            }
            int diasDeGuardia = db.DiasDeGuardiaDeVoluntario(id);
            ViewBag.DiasDeGuardia = diasDeGuardia;
            return View(integrante);
        }

        //
        // GET: /Integrantes/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.CargoId = new SelectList(db.Cargos, "CargoId", "Titulo");
            return View();
        }

        //
        // POST: /Integrantes/Create
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult Create(Integrante integrante)
        {
            if (ModelState.IsValid)
            {
                db.Integrantes.Add(integrante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CargoId = new SelectList(db.Cargos, "CargoId", "Titulo", integrante.CargoId);
            return View(integrante);
        }

        //
        // GET: /Integrantes/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int id = 0)
        {
            Integrante integrante = db.Integrantes.Find(id);
            if (integrante == null)
            {
                return HttpNotFound();
            }
            ViewBag.CargoId = new SelectList(db.Cargos, "CargoId", "Titulo", integrante.CargoId);
            return View(integrante);
        }

        //
        // POST: /Integrantes/Edit/5
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult Edit(Integrante integrante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(integrante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CargoId = new SelectList(db.Cargos, "CargoId", "Titulo", integrante.CargoId);
            return View(integrante);
        }

        //
        // GET: /Integrantes/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int id = 0)
        {
            Integrante integrante = db.Integrantes.Find(id);
            if (integrante == null)
            {
                return HttpNotFound();
            }
            return View(integrante);
        }

        //
        // POST: /Integrantes/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Integrante integrante = db.Integrantes.Find(id);
            db.Integrantes.Remove(integrante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}