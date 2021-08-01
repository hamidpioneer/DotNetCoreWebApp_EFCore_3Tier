using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DatabaseContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Sample> Samples { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DateTime _modifiedDate = new(10, 10, 10);

            #region Sample
            modelBuilder.Entity<Sample>().ToTable("tblSamples");
            modelBuilder.Entity<Sample>().HasKey(s => s.Id);
            modelBuilder.Entity<Sample>().Property(s => s.Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("id");
            modelBuilder.Entity<Sample>().Property(s => s.Name).IsRequired(true).HasMaxLength(255).HasColumnName("name");
            #endregion

            #region Applicant
            modelBuilder.Entity<Applicant>().ToTable("applicants");
            //Primary Key & Identity Column
            modelBuilder.Entity<Applicant>().HasKey(ap => ap.Id);
            modelBuilder.Entity<Applicant>().Property(ap => ap.Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("id");
            //COLUMN SETTINGS
            modelBuilder.Entity<Applicant>().Property(ap => ap.Name).IsRequired(true).HasMaxLength(100).HasColumnName("name");
            modelBuilder.Entity<Applicant>().Property(ap => ap.SurName).IsRequired(true).HasMaxLength(100).HasColumnName("sur_name");
            modelBuilder.Entity<Applicant>().Property(ap => ap.DateOfBirth).IsRequired(true).HasColumnName("date_of_birth");
            modelBuilder.Entity<Applicant>().Property(ap => ap.ContactEmail).IsRequired(false).HasMaxLength(250).HasColumnName("contact_email");
            modelBuilder.Entity<Applicant>().Property(ap => ap.ContactNumber).IsRequired(true).HasMaxLength(25).HasColumnName("contact_number");
            modelBuilder.Entity<Applicant>().Property(ap => ap.CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("creation_date");
            modelBuilder.Entity<Applicant>().Property(ap => ap.ModifiedDate).IsRequired(true).HasDefaultValue(_modifiedDate).HasColumnName("modified_date");
            //RelationShips
            modelBuilder.Entity<Applicant>()
                   .HasMany<Application>(app => app.Applications)
                   .WithOne(ap => ap.Applicant)
                   .HasForeignKey(app => app.Applicant_Id)
                   .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Application Status
            modelBuilder.Entity<ApplicationStatus>().ToTable("application_statuses");
            //Primary Key & Identity Column
            modelBuilder.Entity<ApplicationStatus>().HasKey(apps => apps.Id);
            modelBuilder.Entity<ApplicationStatus>().Property(apps => apps.Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("id");
            //COLUMN SETTINGS
            modelBuilder.Entity<ApplicationStatus>().HasIndex(apps => apps.Name).IsUnique();
            modelBuilder.Entity<ApplicationStatus>().Property(apps => apps.Name).IsRequired(true).HasMaxLength(100).HasColumnName("name");
            modelBuilder.Entity<ApplicationStatus>().Property(apps => apps.CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("creation_date");
            modelBuilder.Entity<ApplicationStatus>().Property(ap => ap.ModifiedDate).IsRequired(true).HasDefaultValue(_modifiedDate).HasColumnName("modified_date");

            //RelationShips
            modelBuilder.Entity<ApplicationStatus>()
                   .HasMany<Application>(app => app.Applications)
                   .WithOne(apps => apps.ApplicationStatus)
                   .HasForeignKey(app => app.ApplicationStatus_Id)
                   .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Grade
            modelBuilder.Entity<Grade>().ToTable("grades");
            //Primary Key & Identity Column
            modelBuilder.Entity<Grade>().HasKey(g => g.Id);
            modelBuilder.Entity<Grade>().Property(g => g.Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("id");
            //COLUMN SETTINGS
            modelBuilder.Entity<Grade>().HasIndex(g => g.Name).IsUnique(); 
            modelBuilder.Entity<Grade>().Property(g => g.Name).IsRequired(true).HasMaxLength(100).HasColumnName("name");
            modelBuilder.Entity<Grade>().HasIndex(g => g.Number).IsUnique();
            modelBuilder.Entity<Grade>().Property(g => g.Number).IsRequired(true).HasColumnName("number");
            modelBuilder.Entity<Grade>().Property(g => g.Capacity).IsRequired(true).HasColumnName("capacity");
            modelBuilder.Entity<Grade>().Property(g => g.CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("creation_date");
            modelBuilder.Entity<Grade>().Property(g => g.ModifiedDate).IsRequired(true).HasDefaultValue(_modifiedDate).HasColumnName("modified_date");

            //RelationShips
            modelBuilder.Entity<Grade>()
                   .HasMany<Application>(g => g.Applications)
                   .WithOne(app => app.Grade)
                   .HasForeignKey(app => app.Grade_Id)
                   .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Application
            modelBuilder.Entity<Application>().ToTable("applications");
            //Primary Key & Identity Column
            modelBuilder.Entity<Application>().HasKey(app => app.Id);
            modelBuilder.Entity<Application>().Property(app => app.Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("id");
            //COLUMN SETTINGS
            modelBuilder.Entity<Application>().Property(app => app.Applicant_Id).IsRequired(true).HasColumnName("applicant_id");
            modelBuilder.Entity<Application>().Property(app => app.Grade_Id).IsRequired(true).HasColumnName("grade_id");
            modelBuilder.Entity<Application>().Property(app => app.ApplicationStatus_Id).HasDefaultValue(1).IsRequired(true).HasColumnName("application_status_id");
            modelBuilder.Entity<Application>().Property(app => app.CreationDate).IsRequired(true).HasDefaultValue(DateTime.UtcNow).HasColumnName("creation_date");
            modelBuilder.Entity<Application>().Property(app => app.ModifiedDate).IsRequired(true).HasDefaultValue(_modifiedDate).HasColumnName("modified_date");
            modelBuilder.Entity<Application>().Property(app => app.SchoolYear).IsRequired(true).HasColumnName("school_year");
            //Relationships

            //Applicant link
            modelBuilder.Entity<Application>()
                 .HasOne<Applicant>(app => app.Applicant)
                 .WithMany(ap => ap.Applications)
                 .HasForeignKey(app => app.Applicant_Id)
                 .OnDelete(DeleteBehavior.NoAction);

            //Grade link
            modelBuilder.Entity<Application>()
                 .HasOne<Grade>(app => app.Grade)
                 .WithMany(ap => ap.Applications)
                 .HasForeignKey(app => app.Grade_Id)
                 .OnDelete(DeleteBehavior.NoAction);

            //Status link
            modelBuilder.Entity<Application>()
                .HasOne<ApplicationStatus>(app => app.ApplicationStatus)
                .WithMany(ap => ap.Applications)
                .HasForeignKey(app => app.ApplicationStatus_Id)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

        }
    }
}
