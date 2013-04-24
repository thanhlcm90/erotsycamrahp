using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using PharmacyStore.Models;

namespace PharmacyStore.Models
{
    [MetadataType(typeof(LS_DOCTOR.DoctorMetadata))]
    public partial class LS_DOCTOR
    {
        internal sealed class DoctorMetadata
        {
            [Display(Name = "Mobile")]
            [StringLength(255)]
            public string Mobile { get; set; }

            [Required(ErrorMessage = "Bạn phải nhập Tên bác sĩ.")]
            [Display(Name = "Họ và tên Bác sĩ")]
            [StringLength(255)]
            public string Fullname { get; set; }

            [Display(Name = "Địa chỉ")]
            [StringLength(255)]
            public string Address { get; set; }

            [Display(Name = "Nơi làm việc")]
            [StringLength(255)]
            public string Hospital { get; set; }

            [Display(Name = "Trạng thái")]
            public char Actflg { get; set; }
        }
    }
}
