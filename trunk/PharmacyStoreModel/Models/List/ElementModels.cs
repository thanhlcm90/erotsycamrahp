using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using PharmacyStore.Models;

namespace PharmacyStore.Models
{
    [MetadataType(typeof(LS_ELEMENT.ElementMetadata))]
    public partial class LS_ELEMENT
    {
        internal sealed class ElementMetadata
        {
            [Required(ErrorMessage = "Bạn phải nhập Tên hoạt chất.")]
            [Display(Name = "Tên hoạt chất")]
            [StringLength(255)]
            public string Name { get; set; }

            [Display(Name = "Trạng thái")]
            public char Actflg { get; set; }
        }
    }
}
