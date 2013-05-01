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
    public class ElementController : Controller
    {
        private PharmacyStoreRepository rep = new PharmacyStoreRepository();

        //
        // GET: /Element/
        [Authorize]
        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Element/GetList
        [HttpPost]
        [Authorize]
        public ActionResult GetList([DataSourceRequest] DataSourceRequest request)
        {
            // Action GetList, dùng cho Grid load danh sách dữ liệu
            var model = rep.GetElementList();
            return Json(model.ToDataSourceResult(request));
        }

        //
        // POST: /Element/GetData
        [HttpPost]
        [Authorize]
        public ActionResult GetData(int id)
        {
            // Action GetData, trả về model dữ liệu
            var model = rep.GetElementInfo(id);
            return Json(new { data = this.RenderPartialViewToString("_FormPartial", model) });
        }

        //
        // POST: /Element/Create

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")]LS_ELEMENT model)
        {
            // Action Create, Save dữ liệu thêm mới gọi từ Ajax request
            // Trả về nội dung String để thông báo tác vụ thành công hay không
            try
            {
                if (model != null)
                {
                    if (rep.InsertElement(model))
                    {
                        // Lưu thành công và trả về Id của model mới
                        return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_SUCCESS, data = model.Id });
                    }
                    else
                    {
                        return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_FAIL });
                    }
                }
                return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_FAIL });
            }
            catch (Exception ex)
            {
                return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_FAIL, data = ex.Message });
            }
        }

        //
        // POST: /Element/Edit
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind]LS_ELEMENT model)
        {
            // Action Edit, Save chỉnh sửa dữ liệu gọi từ Ajax request
            // Trả về nội dung String để thông báo tác vụ thành công hay không
            try
            {
                if (model != null)
                {
                    if (rep.UpdateElement(model))
                    {
                        return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_SUCCESS });
                    }
                    else
                    {
                        return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_FAIL });
                    }
                }
                return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_FAIL });
            }
            catch (Exception ex)
            {
                return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_FAIL, data = ex.Message });
            }
        }

        //
        // POST: /Element/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                if (rep.DeleteElement(id))
                {
                    return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_SUCCESS });
                }
                else
                {
                    return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_FAIL });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_FAIL, data = ex.Message });
            }
        }

        //
        // POST: /Element/Active

        [HttpPost, ActionName("Active")]
        [Authorize]
        public ActionResult Active(int id)
        {
            try
            {
                if (rep.ChangeElementStatus(id, 'A'))
                {
                    return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_SUCCESS });
                }
                else
                {
                    return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_FAIL });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_FAIL, data = ex.Message });
            }
        }

        //
        // POST: /Element/Active

        [HttpPost, ActionName("Deactive")]
        [Authorize]
        public ActionResult Deactive(int id)
        {
            try
            {
                if (rep.ChangeElementStatus(id, 'I'))
                {
                    return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_SUCCESS });
                }
                else
                {
                    return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_FAIL });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_FAIL, data = ex.Message });
            }
        }
        protected override void Dispose(bool disposing)
        {
            rep.Dispose();
            base.Dispose(disposing);
        }
    }
}
