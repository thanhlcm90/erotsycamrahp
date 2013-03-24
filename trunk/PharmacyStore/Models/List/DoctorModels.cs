using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;

namespace PharmacyStore.Models
{
    [Table("LS_DOCTOR")]
	public partial class LS_DOCTOR
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Mobile { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }

        public virtual SY_STORE Store { get; set; }
	}

    public partial class DoctorViewModel
    {
        public int Id { get; set; }
        public int StoreId { get; set; }

        [Display(Name = "Mobile")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập Tên bác sĩ.")]
        [Display(Name = "Tên cửa hàng")]
        public string Fullname { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        public virtual SY_STORE Store { get; set; }
    }
}
