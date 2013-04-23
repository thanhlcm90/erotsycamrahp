using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PharmacyStore.Models;
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
            var model = rep.GetStoreInfo(User.Identity.Name);
            return View(model);
        }

        //
        // POST: /Store/Edit

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind]SY_STORE model)
        {
            if (model  != null)
            {
                rep.UpdateStore(model, User.Identity.Name);
                return Content(CommonMessage.MESSAGE_TRANSACTION_SUCCESS );
            }
            return Content(CommonMessage.MESSAGE_TRANSACTION_FAIL);
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