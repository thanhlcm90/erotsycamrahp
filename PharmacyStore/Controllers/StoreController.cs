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
    public class StoreController : Controller
    {
        private PharmacyStoreContext db = new PharmacyStoreContext();

        //
        // GET: /Store/

        public ActionResult Index()
        {
            var sy_stores = db.SY_STOREs.Include(s => s.User);
            return View(sy_stores.ToList());
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id = 0)
        {
            SY_STORE sy_store = db.SY_STOREs.Find(id);
            if (sy_store == null)
            {
                return HttpNotFound();
            }
            return View(sy_store);
        }

        //
        // GET: /Store/Create

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.SY_USERs, "Id", "UserName");
            return View();
        }

        //
        // POST: /Store/Create

        [HttpPost]
        public ActionResult Create(SY_STORE sy_store)
        {
            if (ModelState.IsValid)
            {
                db.SY_STOREs.Add(sy_store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.SY_USERs, "Id", "UserName", sy_store.UserId);
            return View(sy_store);
        }

        //
        // GET: /Store/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SY_STORE sy_store = db.SY_STOREs.Find(id);
            if (sy_store == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.SY_USERs, "Id", "UserName", sy_store.UserId);
            return View(sy_store);
        }

        //
        // POST: /Store/Edit/5

        [HttpPost]
        public ActionResult Edit(SY_STORE sy_store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sy_store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.SY_USERs, "Id", "UserName", sy_store.UserId);
            return View(sy_store);
        }

        //
        // GET: /Store/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SY_STORE sy_store = db.SY_STOREs.Find(id);
            if (sy_store == null)
            {
                return HttpNotFound();
            }
            return View(sy_store);
        }

        //
        // POST: /Store/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SY_STORE sy_store = db.SY_STOREs.Find(id);
            db.SY_STOREs.Remove(sy_store);
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