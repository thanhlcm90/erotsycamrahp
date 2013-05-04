using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PharmacyStore.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using TugberkUg.MVC.Helpers;

namespace PharmacyStore.Controllers
{
    public class CustomerGroupController : Controller
    {
        private PharmacyStoreRepository rep = new PharmacyStoreRepository();

        //
        // GET: /CustomerGroup/
        [Authorize]
        [HttpPost]
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /CustomerGroup/GetList
        [HttpPost]
        [Authorize]
        public ActionResult GetList([DataSourceRequest] DataSourceRequest request)
        {
            // Action GetList, dùng cho Grid load danh sách dữ liệu
            var model = rep.GetCustomerGroupList();
            return Json(model.ToDataSourceResult(request));
        }

        //
        // POST: /CustomerGroup/GetData
        [HttpPost]
        [Authorize]
        public ActionResult GetData(int id)
        {
            // Action GetData, trả về model dữ liệu
            var model = rep.GetCustomerGroupInfo(id);
            return Json(new { data = this.RenderPartialViewToString("_FormPartial", model) });
        }

        //
        // POST: /CustomerGroup/Create

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")]LS_CUSTOMER_GROUP model)
        {
            // Action Create, Save dữ liệu thêm mới gọi từ Ajax request
            // Trả về nội dung String để thông báo tác vụ thành công hay không
            try
            {
                if (model != null)
                {
                    if (rep.InsertCustomerGroup(model))
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
        // POST: /CustomerGroup/Edit
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind]LS_CUSTOMER_GROUP model)
        {
            // Action Edit, Save chỉnh sửa dữ liệu gọi từ Ajax request
            // Trả về nội dung String để thông báo tác vụ thành công hay không
            try
            {
                if (model != null)
                {
                    if (rep.UpdateCustomerGroup(model))
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
        // POST: /CustomerGroup/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                if (rep.DeleteCustomerGroup(id))
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
        // POST: /CustomerGroup/Active

        [HttpPost, ActionName("Active")]
        [Authorize]
        public ActionResult Active(int id)
        {
            try
            {
                if (rep.ChangeCustomerGroupStatus(id, 'A'))
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
        // POST: /CustomerGroup/Active

        [HttpPost, ActionName("Deactive")]
        [Authorize]
        public ActionResult Deactive(int id)
        {
            try
            {
                if (rep.ChangeCustomerGroupStatus(id, 'I'))
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