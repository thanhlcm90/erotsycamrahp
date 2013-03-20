using PharmacyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmacyStore
{
    public class DoctorController : Controller
    {
        private PharmacyStoreContext db = new PharmacyStoreContext();

        //
        // GET: /Doctor/

        public ActionResult Index()
        {
            return View(db.LS_DOCTORs.ToList());
        }

        //
        // GET: /Doctor/Details/5

        public ActionResult Details(Guid id)
        {
            LS_DOCTOR doctor = db.LS_DOCTORs.Where(p => p.Id == id).SingleOrDefault();
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        //
        // GET: /Doctor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Doctor/Create

        [HttpPost]
        public ActionResult Create(LS_DOCTOR doctor)
        {
            if (ModelState.IsValid)
            {
                db.LS_DOCTORs.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        //
        // GET: /Doctor/Edit/5

        public ActionResult Edit(Guid id)
        {
            LS_DOCTOR doctor = db.LS_DOCTORs.Where(p => p.Id == id).SingleOrDefault();
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        //
        // POST: /Doctor/Edit/5

        [HttpPost]
        public ActionResult Edit(Guid id, LS_DOCTOR doctor)
        {
            if (ModelState.IsValid)
            {
                LS_DOCTOR doctorUpdate = db.LS_DOCTORs.Where(p => p.Id == id).SingleOrDefault();
                CommonFunction.CopyProperties(doctorUpdate, doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        //
        // GET: /Doctor/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Doctor/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
