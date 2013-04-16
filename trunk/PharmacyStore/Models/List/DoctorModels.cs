using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using PharmacyStoreModel;

namespace PharmacyStore.Models
{
    [MetadataType(typeof(LS_DOCTOR.DoctorMetadata))]
    public partial class LS_DOCTOR
    {
        internal sealed class DoctorMetadata
        {
            [Display(Name = "Mobile")]
            public string Mobile { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập Tên bác sĩ.")]
            [Display(Name = "Tên cửa hàng")]
            public string Fullname { get; set; }

            [Display(Name = "Địa chỉ")]
            public string Address { get; set; }

        }
    }
}
