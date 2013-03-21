using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PharmacyStore.Models;

namespace PharmacyStore.Controllers
{
    public class DoctorController : Controller
    {
        private PharmacyStoreContext db = new PharmacyStoreContext();

        //
        // GET: /Doctor/

        public ActionResult Index()
        {
            var ls_doctors = db.LS_DOCTORs.Include(l => l.Store);
            return View(ls_doctors.ToList());
        }

        //
        // GET: /Doctor/Details/5

        public ActionResult Details(int id = 0)
        {
            LS_DOCTOR ls_doctor = db.LS_DOCTORs.Find(id);
            if (ls_doctor == null)
            {
                return HttpNotFound();
            }
            return View(ls_doctor);
        }

        //
        // GET: /Doctor/Create

        public ActionResult Create()
        {
            ViewBag.StoreId = new SelectList(db.SY_STOREs, "Id", "Website");
            return View();
        }

        //
        // POST: /Doctor/Create

        [HttpPost]
        public ActionResult Create(LS_DOCTOR ls_doctor)
        {
            if (ModelState.IsValid)
            {
                db.LS_DOCTORs.Add(ls_doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StoreId = new SelectList(db.SY_STOREs, "Id", "Website", ls_doctor.StoreId);
            return View(ls_doctor);
        }

        //
        // GET: /Doctor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LS_DOCTOR ls_doctor = db.LS_DOCTORs.Find(id);
            if (ls_doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.StoreId = new SelectList(db.SY_STOREs, "Id", "Website", ls_doctor.StoreId);
            return View(ls_doctor);
        }

        //
        // POST: /Doctor/Edit/5

        [HttpPost]
        public ActionResult Edit(LS_DOCTOR ls_doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ls_doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StoreId = new SelectList(db.SY_STOREs, "Id", "Website", ls_doctor.StoreId);
            return View(ls_doctor);
        }

        //
        // GET: /Doctor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LS_DOCTOR ls_doctor = db.LS_DOCTORs.Find(id);
            if (ls_doctor == null)
            {
                return HttpNotFound();
            }
            return View(ls_doctor);
        }

        //
        // POST: /Doctor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            LS_DOCTOR ls_doctor = db.LS_DOCTORs.Find(id);
            db.LS_DOCTORs.Remove(ls_doctor);
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