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
		public string Website { get; set; }
		public string StoreTelephone { get; set; }
		public string StoreTaxNo { get; set; }
		public string StoreName { get; set; }
		public string StoreFax { get; set; }
		public string StoreAddress { get; set; }
		public Guid Id { get; set; }
		public string Email { get; set; }
		public int UserId { get; set; }

        public virtual SY_USER User { get; set; }
        public virtual List<LS_DOCTOR> ListDoctor { get; set; }
	}
}
