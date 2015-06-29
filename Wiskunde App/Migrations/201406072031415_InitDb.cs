namespace Wiskunde_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeerlingGemaakteOefeningens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LeerlingID = c.Int(nullable: false),
                        AntwoordLeerling = c.Int(nullable: false),
                        OefeningenID = c.Int(nullable: false),
                        NiveauID = c.Int(nullable: false),
                        Datum = c.String(),
                        Level_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Leerlings", t => t.LeerlingID)
                .ForeignKey("dbo.Levels", t => t.Level_ID)
                .ForeignKey("dbo.Oefeningens", t => t.OefeningenID)
                .Index(t => t.LeerlingID)
                .Index(t => t.OefeningenID)
                .Index(t => t.Level_ID);
            
            CreateTable(
                "dbo.Leerlings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Voornaam = c.String(),
                        Familienaam = c.String(),
                        Klasnummer = c.Int(nullable: false),
                        KlasID = c.Int(),
                        SchoolID = c.Int(),
                        Level = c.Int(nullable: false),
                        GemaakteOefeningen = c.Int(nullable: false),
                        FotoLeerling = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Klas", t => t.KlasID)
                .Index(t => t.KlasID);
            
            CreateTable(
                "dbo.Klas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KlasNaam = c.String(),
                        MaximumAantalLeerlingen = c.Int(nullable: false),
                        school_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Schools", t => t.school_ID)
                .Index(t => t.school_ID);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naam = c.String(nullable: false),
                        Adres = c.String(nullable: false),
                        Huisnummer = c.Int(nullable: false),
                        Postcode = c.Int(nullable: false),
                        Gemeente = c.String(nullable: false),
                        LogoUrl = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Thema = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Resultatens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LeerlingID = c.Int(nullable: false),
                        Score = c.Int(nullable: false),
                        LevelID = c.Int(nullable: false),
                        Datum = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Leerlings", t => t.LeerlingID)
                .ForeignKey("dbo.Levels", t => t.LevelID)
                .Index(t => t.LeerlingID)
                .Index(t => t.LevelID);
            
            CreateTable(
                "dbo.Oefeningens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Getal1 = c.Int(nullable: false),
                        Getal2 = c.Int(nullable: false),
                        Getal3 = c.Int(nullable: false),
                        SoortID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Soorts", t => t.SoortID)
                .Index(t => t.SoortID);
            
            CreateTable(
                "dbo.Soorts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SoortNaam = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Leerkrachts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        VoorNaam = c.String(),
                        FamilieNaam = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LeerkrachtSchoolKlas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SchoolID = c.Int(),
                        KlasID = c.Int(),
                        LeerKrachtID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Klas", t => t.KlasID)
                .ForeignKey("dbo.Leerkrachts", t => t.LeerKrachtID)
                .ForeignKey("dbo.Schools", t => t.SchoolID)
                .Index(t => t.SchoolID)
                .Index(t => t.KlasID)
                .Index(t => t.LeerKrachtID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Voornaam = c.String(),
                        Familienaam = c.String(),
                        SchoolID = c.Int(),
                        KlasID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LeerkrachtSchoolKlas", "SchoolID", "dbo.Schools");
            DropForeignKey("dbo.LeerkrachtSchoolKlas", "LeerKrachtID", "dbo.Leerkrachts");
            DropForeignKey("dbo.LeerkrachtSchoolKlas", "KlasID", "dbo.Klas");
            DropForeignKey("dbo.LeerlingGemaakteOefeningens", "OefeningenID", "dbo.Oefeningens");
            DropForeignKey("dbo.Oefeningens", "SoortID", "dbo.Soorts");
            DropForeignKey("dbo.LeerlingGemaakteOefeningens", "Level_ID", "dbo.Levels");
            DropForeignKey("dbo.Resultatens", "LevelID", "dbo.Levels");
            DropForeignKey("dbo.Resultatens", "LeerlingID", "dbo.Leerlings");
            DropForeignKey("dbo.LeerlingGemaakteOefeningens", "LeerlingID", "dbo.Leerlings");
            DropForeignKey("dbo.Klas", "school_ID", "dbo.Schools");
            DropForeignKey("dbo.Leerlings", "KlasID", "dbo.Klas");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.LeerkrachtSchoolKlas", new[] { "LeerKrachtID" });
            DropIndex("dbo.LeerkrachtSchoolKlas", new[] { "KlasID" });
            DropIndex("dbo.LeerkrachtSchoolKlas", new[] { "SchoolID" });
            DropIndex("dbo.Oefeningens", new[] { "SoortID" });
            DropIndex("dbo.Resultatens", new[] { "LevelID" });
            DropIndex("dbo.Resultatens", new[] { "LeerlingID" });
            DropIndex("dbo.Klas", new[] { "school_ID" });
            DropIndex("dbo.Leerlings", new[] { "KlasID" });
            DropIndex("dbo.LeerlingGemaakteOefeningens", new[] { "Level_ID" });
            DropIndex("dbo.LeerlingGemaakteOefeningens", new[] { "OefeningenID" });
            DropIndex("dbo.LeerlingGemaakteOefeningens", new[] { "LeerlingID" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LeerkrachtSchoolKlas");
            DropTable("dbo.Leerkrachts");
            DropTable("dbo.Soorts");
            DropTable("dbo.Oefeningens");
            DropTable("dbo.Resultatens");
            DropTable("dbo.Levels");
            DropTable("dbo.Schools");
            DropTable("dbo.Klas");
            DropTable("dbo.Leerlings");
            DropTable("dbo.LeerlingGemaakteOefeningens");
        }
    }
}
