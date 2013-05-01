using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PharmacyStore.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using TugberkUg.MVC.Helpers;

namespace PharmacyStore.Controllers
{
    public class StoreController : Controller
    {
        // Khai báo Repository để tương tác dữ liệu
        PharmacyStoreRepository rep = new PharmacyStoreRepository();

        //
        // GET: /Store/
        [Authorize]
        [HttpPost]
        public ActionResult Index()
        {
            // Action Default(Index) trả về View kèm theo dữ liệu Store
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
            // Action Edit, Save chỉnh sửa dữ liệu gọi từ Ajax request
            // Trả về nội dung String để thông báo tác vụ thành công hay không
            try
            {
                if (model != null)
                {
                    rep.UpdateStore(model, User.Identity.Name);
                    return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_SUCCESS });
                }
                return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_FAIL });
            }
            catch (Exception ex)
            {
                return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_FAIL, data = ex.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult GetData()
        {
            // Action GetData, lấy dữ liệu Store gọi từ Ajax request
            // Trả về nội dung Json với dữ liệu là nội dung Html được render từ Partial kèm theo model
            var model = rep.GetStoreInfo(User.Identity.Name);
            return Json(new { data = this.RenderPartialViewToString("_FormPartial", model) });
        }

        protected override void Dispose(bool disposing)
        {
            rep.Dispose();
            base.Dispose(disposing);
        }
    }
}