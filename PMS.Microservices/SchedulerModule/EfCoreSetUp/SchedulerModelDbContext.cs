using LoginService.Models;
using Microsoft.EntityFrameworkCore;
using SchedulerModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerModule.EfCoreSetUp
{

    public partial class SchedulerModelDbContext :DbContext
    {

        public SchedulerModelDbContext()
        {
        }

        public SchedulerModelDbContext(DbContextOptions<SchedulerModelDbContext> options)
            : base(options)
        {
        }


        public DbSet<AppointmentDetails> appointmentDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=MAMTAY-MSL2\SQLEXPRESS;Initial Catalog=pmsDb;User ID = sa;Password = password_123");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Ignore<Gender>();
            builder.Ignore<ApplicationRole>();
            builder.Ignore<Status>();
            builder.Ignore<ApplicationUser>();

        }
    }
}
