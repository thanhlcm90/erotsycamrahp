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

        [Authorize]
        public ActionResult Index()
        {
            List<StoreViewModel> sy_stores = (from p in db.SY_STOREs.ToList()
                                       select new StoreViewModel
                                       {
                                           Id = p.Id,
                                           StoreName = p.StoreName,
                                           StoreAddress = p.StoreAddress,
                                           Email = p.Email,
                                           ListDoctor = String.Join("; ", p.ListDoctor),
                                           OwnerFullname = p.User.Fullname,
                                           StoreFax = p.StoreFax,
                                           StoreTaxNo = p.StoreTaxNo,
                                           StoreTelephone = p.StoreTelephone,
                                           Website = p.Website
                                       }).ToList();
            return View(sy_stores);
        }

        //
        // GET: /Store/Details/5

        [Authorize]
        public ActionResult Details(int id = 0)
        {
            StoreViewModel  sy_store = (from p in db.SY_STOREs.ToList()
                                        where p.Id==id
                                        select new StoreViewModel 
                                        {
                                            Id=p.Id,
                                            StoreName=p.StoreName,
                                            StoreAddress=p.StoreAddress,
                                            Email=p.Email,
                                            ListDoctor = String.Join("; ",p.ListDoctor),
                                            OwnerFullname=p.User.Fullname,
                                            StoreFax=p.StoreFax,
                                            StoreTaxNo=p.StoreTaxNo,
                                            StoreTelephone=p.StoreTelephone,
                                            Website=p.Website
                                        }).SingleOrDefault();
            if (sy_store == null)
            {
                return HttpNotFound();
            }
            return View(sy_store);
        }

        //
        // GET: /Store/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.SY_USERs, "Id", "UserName");
            return View();
        }

        //
        // POST: /Store/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(StoreViewModel sy_store)
        {
            if (sy_store != null && ModelState.IsValid)
            {
                SY_STORE _new = new SY_STORE();
                CommonFunction.CopyProperties(sy_store, _new);
                _new.UserId = (from p in db.SY_USERs where p.UserName == User.Identity.Name select p.Id).SingleOrDefault();
                db.SY_STOREs.Add(_new);
                db.SaveChanges();
            }
            return View(sy_store);
        }

        //
        // POST: /Store/Edit

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(StoreViewModel sy_store)
        {
            if (sy_store!=null && ModelState.IsValid)
            {
                SY_STORE _edit = db.SY_STOREs.Find(sy_store.Id);
                CommonFunction.CopyProperties(sy_store, _edit);
                db.SaveChanges();
            }
            return View(sy_store);
        }

        //
        // POST: /Store/Delete

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(StoreViewModel sy_store)
        {
            SY_STORE _delete = db.SY_STOREs.Find(sy_store.Id);
            if (sy_store == null)
            {
                db.SY_STOREs.Remove(_delete);
                db.SaveChanges();
                return HttpNotFound();
            }
            return View(sy_store);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}