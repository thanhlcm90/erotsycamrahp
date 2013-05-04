using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using PharmacyStore.Models;

namespace PharmacyStore.Models
{
    [MetadataType(typeof(LS_DISEASE.ElementMetadata))]
    public partial class LS_DISEASE
    {
        internal sealed class ElementMetadata
        {
            [Required(ErrorMessage = "Bạn phải nhập Tên bệnh.")]
            [Display(Name = "Tên bệnh")]
            [StringLength(255)]
            public string Name { get; set; }

            [Display(Name = "Mô tả bệnh")]
            [StringLength(255)]
            public string Description { get; set; }

            [Display(Name = "Trạng thái")]
            public char Actflg { get; set; }
        }
    }
}
