using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Wiskunde_App.Models;

namespace Wiskunde_App.DataAccess.Context
{
    public class WiskundeContext : IdentityDbContext<ApplicationUser>
    {

        public WiskundeContext()
            : base("WiskundeContext")
        {
            this.Database.Log = new MyLogger().Log;
        }
        public virtual DbSet<Leerling> Leerling { get; set; }

        public virtual DbSet<Level> Niveau { get; set; }

        public virtual DbSet<Resultaten> Resultaat { get; set; }

        public virtual DbSet<Klas> Klas { get; set; }

        public virtual DbSet<Oefeningen> Oefening { get; set; }

        public virtual DbSet<Leerkracht> Leerkracht { get; set; }

        public virtual DbSet<School> School { get; set; }

        public virtual DbSet<LeerkrachtSchoolKlas> LeerkrachtSchoolKlas { get; set; }

        public virtual DbSet<LeerlingGemaakteOefeningen> Gemaakteoefeningenleerling { get; set; }

        public virtual DbSet<Soort> Soorten { get; set; }

        public class MyLogger
        {
            public void Log(string message)
            {
                Debug.WriteLine(message);
            }

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }

            // Keep this:
            modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");

            // Change TUser to ApplicationUser everywhere else - 
            // IdentityUser and ApplicationUser essentially 'share' the AspNetUsers Table in the database:
            EntityTypeConfiguration<ApplicationUser> table =
                modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");

            table.Property((ApplicationUser u) => u.UserName).IsRequired();

            // EF won't let us swap out IdentityUserRole for ApplicationUserRole here:
            modelBuilder.Entity<ApplicationUser>().HasMany<IdentityUserRole>((ApplicationUser u) => u.Roles);
            modelBuilder.Entity<IdentityUserRole>().HasKey((IdentityUserRole r) =>
                new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("AspNetUserRoles");

            // Leave this alone:
            EntityTypeConfiguration<IdentityUserLogin> entityTypeConfiguration =
                modelBuilder.Entity<IdentityUserLogin>().HasKey((IdentityUserLogin l) =>
                    new
                    {
                        UserId = l.UserId,
                        LoginProvider = l.LoginProvider,
                        ProviderKey
                            = l.ProviderKey
                    }).ToTable("AspNetUserLogins");

            entityTypeConfiguration.HasRequired<IdentityUser>((IdentityUserLogin u) => u.User);
            EntityTypeConfiguration<IdentityUserClaim> table1 =
                modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims");

            table1.HasRequired<IdentityUser>((IdentityUserClaim u) => u.User);

            // Add this, so that IdentityRole can share a table with ApplicationRole:
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");

            // Change these from IdentityRole to ApplicationRole:
            EntityTypeConfiguration<ApplicationRole> entityTypeConfiguration1 =
                modelBuilder.Entity<ApplicationRole>().ToTable("AspNetRoles");

            entityTypeConfiguration1.Property((ApplicationRole r) => r.Name).IsRequired();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
    }
}

  