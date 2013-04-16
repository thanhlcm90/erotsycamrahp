using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PharmacyStoreModel;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace PharmacyStore.Controllers
{
    public class StoreController : Controller
    {
        PharmacyStoreRepository rep = new PharmacyStoreRepository();
        //
        // GET: /Store/

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult GetStoreList([DataSourceRequest] DataSourceRequest request)
        {
            var model = rep.GetStoreList();
            return Json(model.ToDataSourceResult(request));
        }

        //
        // GET: /Store/Details/5

        [Authorize]
        public ActionResult Details(int id = 0)
        {
            var model = rep.GetStoreInfo(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //
        // GET: /Store/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(rep.GetUserList(), "Id", "UserName");
            return View();
        }

        //
        // POST: /Store/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(SY_STORE model)
        {
            if (model != null && ModelState.IsValid)
            {
                model.UserId = rep.GetUserInfoFromUsername(User.Identity.Name).Id;
                rep.InsertStore(model);
            }
            return View(model);
        }

        //
        // POST: /Store/Edit

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(SY_STORE model)
        {
            if (model != null && ModelState.IsValid)
            {
                rep.UpdateStore(model);
            }
            return View(model);
        }

        //
        // POST: /Store/Delete

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id)
        {
            rep.DeleteStore(id);
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            rep.Dispose();
            base.Dispose(disposing);
        }
    }
}