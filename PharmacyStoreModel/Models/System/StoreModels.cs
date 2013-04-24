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
            [StringLength(255)]
            public string Website { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập số điện thoại.")]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Điện thoại")]
            [StringLength(255)]
            public string StoreTelephone { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập Mã số thuê.")]
            [Display(Name = "Mã số thuế")]
            [StringLength(255)]
            public string StoreTaxNo { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập Tên cửa hàng.")]
            [Display(Name = "Tên cửa hàng")]
            [StringLength(255)]
            public string StoreName { get; set; }

            [Display(Name = "Fax")]
            [StringLength(255)]
            public string StoreFax { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập Địa chỉ.")]
            [Display(Name = "Địa chỉ")]
            [StringLength(255)]
            public string StoreAddress { get; set; }

            [Display(Name = "Email")]
            [StringLength(255)]
            public string Email { get; set; }
        }
    }
}
