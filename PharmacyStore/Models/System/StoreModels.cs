using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace PharmacyStore.Models
{
    [MetadataType(typeof(SY_STORE.StoreMetadata))]
    public partial class SY_STORE
    {
        internal sealed class StoreMetadata
        {
            [Display(Name = "Website")]
            public string Website { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập số điện thoại.")]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Điện thoại")]
            public string StoreTelephone { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập Mã số thuê.")]
            [Display(Name = "Mã số thuế")]
            public string StoreTaxNo { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập Tên cửa hàng.")]
            [Display(Name = "Tên cửa hàng")]
            public string StoreName { get; set; }

            [Display(Name = "Fax")]
            public string StoreFax { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập Địa chỉ.")]
            [Display(Name = "Địa chỉ")]
            public string StoreAddress { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }
            public int UserId { get; set; }

            [Display(Name = "Tên chủ tiệm thuốc")]
            public string OwnerFullname { get; set; }

            [Display(Name = "Danh sách bác sĩ")]
            public string ListDoctor { get; set; }
        }
    }
}
