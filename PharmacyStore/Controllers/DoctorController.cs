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
    public class DoctorController : Controller
    {
        private PharmacyStoreRepository rep = new PharmacyStoreRepository();

        //
        // GET: /Doctor/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Doctor/GetList
        [HttpPost]
        [Authorize]
        public ActionResult GetList([DataSourceRequest] DataSourceRequest request)
        {
            // Action GetList, dùng cho Grid load danh sách dữ liệu
            var model = rep.GetDoctorList();
            return Json(model.ToDataSourceResult(request));
        }

        //
        // POST: /Doctor/GetData
        [HttpPost]
        [Authorize]
        public ActionResult GetData(int id)
        {
            // Action GetData, trả về model dữ liệu
            var model = rep.GetDoctorInfo(id);
            return Json(new { data = this.RenderPartialViewToString("_FormPartial", model) });
        }

        //
        // POST: /Doctor/Create

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Id")]LS_DOCTOR model)
        {
            // Action Create, Save dữ liệu thêm mới gọi từ Ajax request
            // Trả về nội dung String để thông báo tác vụ thành công hay không
            try
            {
                if (model != null)
                {
                    if (rep.InsertDoctor(model))
                    {
                        // Lưu thành công và trả về Id của model mới
                        return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_SUCCESS, data = model.Id });
                    }
                    else
                    {
                        return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_FAIL});
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
        // POST: /Doctor/Edit
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind]LS_DOCTOR model)
        {
            // Action Edit, Save chỉnh sửa dữ liệu gọi từ Ajax request
            // Trả về nội dung String để thông báo tác vụ thành công hay không
            try
            {
                if (model != null)
                {
                    if (rep.UpdateDoctor(model))
                    {
                        return Json(new { result = CommonMessage.MESSAGE_TRANSACTION_SUCCESS});
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
        // POST: /Doctor/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                if (rep.DeleteDoctor(id))
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
        // POST: /Doctor/Active

        [HttpPost, ActionName("Active")]
        [Authorize]
        public ActionResult Active(int id)
        {
            try
            {
                if (rep.ChangeDoctorStatus(id,'A'))
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
        // POST: /Doctor/Active

        [HttpPost, ActionName("Deactive")]
        [Authorize]
        public ActionResult Deactive(int id)
        {
            try
            {
                if (rep.ChangeDoctorStatus(id, 'I'))
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