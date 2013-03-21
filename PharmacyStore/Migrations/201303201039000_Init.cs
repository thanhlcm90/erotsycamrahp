namespace PharmacyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SY_USER",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Gender = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Mobile = c.String(),
                        UserRefer = c.String(),
                        Identification = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SY_STORE",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Website = c.String(),
                        StoreTelephone = c.String(nullable: false),
                        StoreTaxNo = c.String(nullable: false),
                        StoreName = c.String(nullable: false),
                        StoreFax = c.String(),
                        StoreAddress = c.String(nullable: false),
                        Email = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SY_USER", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LS_DOCTOR",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        Mobile = c.String(),
                        Fullname = c.String(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SY_STORE", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.LS_DOCTOR", new[] { "StoreId" });
            DropIndex("dbo.SY_STORE", new[] { "UserId" });
            DropForeignKey("dbo.LS_DOCTOR", "StoreId", "dbo.SY_STORE");
            DropForeignKey("dbo.SY_STORE", "UserId", "dbo.SY_USER");
            DropTable("dbo.LS_DOCTOR");
            DropTable("dbo.SY_STORE");
            DropTable("dbo.SY_USER");
        }
    }
}
