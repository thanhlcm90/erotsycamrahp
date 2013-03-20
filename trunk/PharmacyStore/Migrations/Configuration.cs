namespace PharmacyStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<PharmacyStore.PharmacyStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PharmacyStore.PharmacyStoreContext context)
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("PharmacyStoreConnection", "SY_USER", "Id", "UserName", autoCreateTables: true);
            }
            if (!Roles.RoleExists("Administrator"))
            {
                Roles.CreateRole("Administrator");
            }
            if (!WebSecurity.UserExists("thanhlcm"))
                WebSecurity.CreateUserAndAccount(
                    "thanhlcm",
                    "P@$$w0rd!", new { Birthdate = new DateTime(1990, 03, 23), });
            if (!Roles.GetRolesForUser("thanhlcm").Contains("Administrator"))
                Roles.AddUsersToRoles(new[] { "thanhlcm" }, new[] { "Administrator" });
        }
    }
}
