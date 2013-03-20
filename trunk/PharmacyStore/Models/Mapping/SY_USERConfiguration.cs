using PharmacyStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PharmacyStore.Models.Mapping
{
    public class SY_USERConfiguration : EntityTypeConfiguration<SY_USER>
    {
        public SY_USERConfiguration()
        {
            this.HasKey(p => new { p.Id });
            this.Property(p => p.Birthdate).IsRequired();
            this.Property(p => p.Email).IsRequired();
            this.Property(p => p.Gender).IsRequired();
            this.Property(p => p.UserName).IsRequired();
            this.Property(p => p.Identification).IsRequired();
        }
    }
}