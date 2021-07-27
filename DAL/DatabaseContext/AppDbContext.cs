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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sample>().ToTable("tblSamples");
            modelBuilder.Entity<Sample>().HasKey(s => s.Id);
            modelBuilder.Entity<Sample>().Property(s => s.Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("id");
            modelBuilder.Entity<Sample>().Property(s => s.Name).IsRequired(true).HasMaxLength(255).HasColumnName("name");
        }
    }
}
