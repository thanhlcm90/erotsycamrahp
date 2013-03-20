using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;

namespace PharmacyStore.Models
{
	[Table("SY_USER")]
    public partial class SY_USER
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Gender { get; set; }
		public DateTime Birthdate { get; set; }
		public string Mobile { get; set; }
		public string UserRefer { get; set; }
		public string Identification { get; set; }
        
        public virtual List<SY_STORE> ListStore {get;set;}
	}
}
