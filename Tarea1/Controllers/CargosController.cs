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
    public class CargosController : Controller
    {
        private Tarea1DbContext db = new Tarea1DbContext();

        //
        // GET: /Cargos/

        public ActionResult Index()
        {
            return View(db.Cargos.ToList());
        }

        //
        // GET: /Cargos/Details/5

        public ActionResult Details(int id = 0)
        {
            Cargo cargo = db.Cargos.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        //
        // GET: /Cargos/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cargos/Create
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult Create(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Cargos.Add(cargo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargo);
        }

        //
        // GET: /Cargos/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int id = 0)
        {
            Cargo cargo = db.Cargos.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        //
        // POST: /Cargos/Edit/5
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult Edit(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargo);
        }

        //
        // GET: /Cargos/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int id = 0)
        {
            Cargo cargo = db.Cargos.Find(id);
            if (cargo == null)
            {
                return HttpNotFound();
            }
            return View(cargo);
        }

        //
        // POST: /Cargos/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cargo cargo = db.Cargos.Find(id);
            db.Cargos.Remove(cargo);
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