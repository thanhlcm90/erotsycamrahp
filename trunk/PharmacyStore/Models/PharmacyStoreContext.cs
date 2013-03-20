using PharmacyStore.Models.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PharmacyStore.Models;

namespace PharmacyStore
{

    public class PharmacyStoreContext : DbContext
    {
        private static string GenerateConnectionString(string connectionString)
        {
            var cs = System.Configuration.ConfigurationManager
                         .ConnectionStrings[connectionString];

            SqlConnectionStringBuilder sb =
                 new SqlConnectionStringBuilder(cs.ConnectionString);
            EntityConnectionStringBuilder builder =
                 new EntityConnectionStringBuilder();
            builder.Provider = cs.ProviderName;
            builder.ProviderConnectionString = sb.ConnectionString;
            builder.Metadata = "res://*/PharmacyStoreContext.csdl|" +
                  "res://*/PharmacyStoreContext.ssdl|res://*/PharmacyStoreContext.msl";
            return builder.ToString();
        }

        public PharmacyStoreContext()
            : base("PharmacyStoreConnection")
        {
        }

        public PharmacyStoreContext(string connectionName)
            : base(GenerateConnectionString(connectionName))
        {
        }

        public DbSet<SY_USER> SY_USERs { get; set; }
        public DbSet<SY_STORE> SY_STOREs { get; set; }
        public DbSet<LS_DOCTOR> LS_DOCTORs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new SY_STOREConfiguration());
            modelBuilder.Configurations.Add(new LS_DOCTORConfiguration());
        }
    }
}