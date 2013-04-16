using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PharmacyStoreModel;

namespace PharmacyStore.Controllers
{
    public class DoctorController : Controller
    {
        private PharmacyStoreRepository rep = new PharmacyStoreRepository();

        //
        // GET: /Doctor/

        public ActionResult Index()
        {
            var model = rep.GetDoctorList();
            return View(model);
        }

        //
        // GET: /Doctor/Details/5

        public ActionResult Details(int id = 0)
        {
            var model = rep.GetDoctorInfo(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //
        // GET: /Doctor/Create

        public ActionResult Create()
        {
            ViewBag.StoreId = new SelectList(rep.GetStoreList(), "Id", "Website");
            return View();
        }

        //
        // POST: /Doctor/Create

        [HttpPost]
        public ActionResult Create(LS_DOCTOR model)
        {
            if (ModelState.IsValid)
            {
                rep.InsertDoctor(model);
                return RedirectToAction("Index");
            }
            
            ViewBag.StoreId = new SelectList(rep.GetStoreList(), "Id", "Website");
            return View(model);
        }

        //
        // GET: /Doctor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var model =rep.GetDoctorInfo(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.StoreId = new SelectList(rep.GetStoreList(), "Id", "Website", model.StoreId);
            return View(model);
        }

        //
        // POST: /Doctor/Edit/5

        [HttpPost]
        public ActionResult Edit(LS_DOCTOR model)
        {
            if (ModelState.IsValid)
            {
                rep.UpdateDoctor(model);
                return RedirectToAction("Index");
            }
            ViewBag.StoreId = new SelectList(rep.GetStoreList(), "Id", "Website", model.StoreId);
            return View(model);
        }

        //
        // GET: /Doctor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var model=rep.GetDoctorInfo(id);
            return View(model);
        }

        //
        // POST: /Doctor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            rep.DeleteDoctor(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            rep.Dispose();
            base.Dispose(disposing);
        }
    }
}