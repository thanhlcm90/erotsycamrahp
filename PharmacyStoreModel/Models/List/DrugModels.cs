using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using PharmacyStore.Models;

namespace PharmacyStore.Models
{
    [MetadataType(typeof(LS_DRUG.DrugMetadata))]
    public partial class LS_DRUG
    {
        internal sealed class DrugMetadata
        {
            [Required(ErrorMessage = "Bạn phải nhập Mã thuốc, vật tư.")]
            [Display(Name = "Mã thuốc, vật tư")]
            [StringLength(50)]
            public  string Code { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập Tên thuốc, vật tư.")]
            [Display(Name = "Tên thuốc, vật tư")]
            [StringLength(255)]
            public string Name { get; set; }

            [Display(Name = "Mã vạch")]
            public  long? Barcode { get; set; }

            [Required(ErrorMessage = "Bạn phải chọn Nhóm thuốc, vật tư.")]
            [Display(Name = "Nhóm thuốc, vật tư")]
            public  int GroupId { get; set; }

            [Display(Name = "Nhà cung cấp")]
            public  int? ManufactureId { get; set; }

            [Required(ErrorMessage = "Bạn phải chọn Đơn vị tính 1.")]
            [Display(Name = "Đơn vị tính 1")]
            public  int CalcUnit1Id { get; set; }

            [Required(ErrorMessage = "Bạn phải chọn Đơn vị tính 2.")]
            [Display(Name = "Đơn vị tính 2")]
            public  int CalcUnit2Id { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập tỉ lệ.")]
            [Display(Name = "Tỉ lệ ĐVT2 / ĐVT1")]
            public  int CalcUniAmout { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập Giá nhập.")]
            [Display(Name = "Giá nhập")]
            [Range(1,int.MaxValue,ErrorMessage="Số tiền nhập phải lớn hơn 0")]
            public  int PriceDefault { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập Giá bán buôn.")]
            [Display(Name = "Giá bán buôn")]
            [Range(1, int.MaxValue, ErrorMessage = "Số tiền nhập phải lớn hơn 0")]
            public  int PriceWholeSale { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập Giá bán lẻ.")]
            [Display(Name = "Giá bán lẻ")]
            [Range(1, int.MaxValue, ErrorMessage = "Số tiền nhập phải lớn hơn 0")]
            public  int PriceRetail { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập Giá niêm yết.")]
            [Display(Name = "Giá niêm yết")]
            [Range(1, int.MaxValue, ErrorMessage = "Số tiền nhập phải lớn hơn 0")]
            public  int PriceStock { get; set; }

            [Display(Name = "Tồn tối đa")]
            [Range(1, int.MaxValue, ErrorMessage = "Số lượng nhập phải lớn hơn 0")]
            public  int? BacklogMax { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập Số lượng tồn tối thiểu.")]
            [Display(Name = "Tồn tối thiểu")]
            [Range(1, int.MaxValue, ErrorMessage = "Số lượng nhập phải lớn hơn 0")]
            public  int BacklogMin { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập Đời sống thuốc.")]
            [Display(Name = "Đời sống thuốc")]
            [Range(1, int.MaxValue, ErrorMessage = "Số lượng nhập phải lớn hơn 0")]
            public  int LifeDay { get; set; }

            [Display(Name = "Vị trí tủ thuốc")]
            public  int? CabinetId { get; set; }

            [Display(Name = "Nhiệt độ bảo quản")]
            public  int? PreserveTemp { get; set; }

            [Display(Name = "Quy cách")]
            public  string Standard { get; set; }

            [Display(Name = "Số đăng ký")]
            public  string RegisterNo { get; set; }

            [Display(Name = "Công ty đăng ký")]
            public  string RegisterCompany { get; set; }

            [Display(Name = "Dạng bào chế")]
            public  string MakeUpForm { get; set; }

            [Display(Name = "Thông tin thuốc")]
            public  string DrugInformation { get; set; }

            [Display(Name = "Liều dùng")]
            public string Dose { get; set; }
        }
    }
}
