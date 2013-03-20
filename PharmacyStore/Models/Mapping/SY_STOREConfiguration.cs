using PharmacyStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PharmacyStore.Models.Mapping
{
    public class SY_STOREConfiguration : EntityTypeConfiguration<SY_STORE>
    {
        public SY_STOREConfiguration()
        {
            this.HasKey(p => new { p.Id });
            this.Property(p => p.StoreAddress).IsRequired();
            this.Property(p => p.StoreName).IsRequired();
            this.Property(p => p.StoreTaxNo).IsRequired();
            this.HasRequired(p => p.User).WithMany(p => p.ListStore).HasForeignKey(p => p.UserId);
        }
    }
}