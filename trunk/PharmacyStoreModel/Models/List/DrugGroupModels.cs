using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using PharmacyStore.Models;

namespace PharmacyStore.Models
{
    [MetadataType(typeof(LS_DRUG_GROUP.DrugGroupMetadata))]
    public partial class LS_DRUG_GROUP
    {
        internal sealed class DrugGroupMetadata
        {
            [Required(ErrorMessage = "Bạn phải nhập Tên nhóm thuốc, vật tư.")]
            [Display(Name = "Tên nhóm thuốc, vật tư")]
            [StringLength(255)]
            public string Name { get; set; }

            [Display(Name = "Trạng thái")]
            public char Actflg { get; set; }
        }
    }
}
