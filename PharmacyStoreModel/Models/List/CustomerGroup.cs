using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using PharmacyStore.Models;

namespace PharmacyStore.Models
{
    [MetadataType(typeof(LS_CUSTOMER_GROUP.ElementMetadata))]
    public partial class LS_CUSTOMER_GROUP
    {
        internal sealed class ElementMetadata
        {
            [Required(ErrorMessage = "Bạn phải nhập Tên nhóm.")]
            [Display(Name = "Tên nhóm")]
            [StringLength(255)]
            public string Name { get; set; }

            [Display(Name = "InDiscount")]
            public int InDiscount { get; set; }

            [Display(Name = "OutDiscount")]
            public int OutDiscount { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập ghi chú.")]
            [Display(Name = "Ghi chú")]
            [StringLength(255)]
            public string Note { get; set; }

            [Display(Name = "Trạng thái")]
            public char Actflg { get; set; }
        }
    }
}
