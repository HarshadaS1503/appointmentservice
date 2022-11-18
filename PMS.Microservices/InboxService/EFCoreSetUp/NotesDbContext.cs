using InboxService.Models;
using LoginService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InboxService.EFCoreSetUp
{
    public class NotesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=MAMTAY-MSL2\SQLEXPRESS;Initial Catalog=pmsDb;User ID = sa;Password = password_123");
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<ApplicationRole>().ToTable("Roles");
        //    builder.Entity<ApplicationUser>().ToTable("Users");
        //}

        public DbSet<Notes> Notes { get; set; }
        //public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
