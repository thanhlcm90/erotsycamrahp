using PharmacyStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PharmacyStore.Models.Mapping
{
    public class LS_DOCTORConfiguration : EntityTypeConfiguration<LS_DOCTOR>
    {
        public LS_DOCTORConfiguration()
        {
            this.HasKey(p => new { p.Id });
            this.Property(p => p.Fullname).IsRequired();
            this.HasRequired(p => p.Store ).WithMany(p => p.ListDoctor).HasForeignKey(p => p.StoreId);
        }
    }
}