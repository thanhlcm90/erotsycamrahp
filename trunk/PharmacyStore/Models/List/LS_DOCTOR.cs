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
        public Guid StoreId { get; set; }
        public string Mobile { get; set; }
        public Guid Id { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }

        public virtual SY_STORE Store { get; set; }
	}
}
