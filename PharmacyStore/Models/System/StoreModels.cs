using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;

namespace PharmacyStore.Models
{
    [Table("SY_STORE")]
    public partial class SY_STORE
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Website { get; set; }
        public string StoreTelephone { get; set; }
        public string StoreTaxNo { get; set; }
        public string StoreName { get; set; }
        public string StoreFax { get; set; }
        public string StoreAddress { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }

        public virtual SY_USER User { get; set; }
        public virtual List<LS_DOCTOR> ListDoctor { get; set; }
    }

	public partial class StoreViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Website")]
		public string Website { get; set; }

        [Required(ErrorMessage="Bạn phải nhập số điện thoại.")]
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
