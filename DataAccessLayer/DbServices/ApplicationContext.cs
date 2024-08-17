using Microsoft.EntityFrameworkCore;
using ModelAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DbServices
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options) { }
        public DbSet<AdminModel> AdminRecords { get; set; }
        public DbSet<JyotishModel> JyotishRecords { get; set; }
        public DbSet<PendingJyotishModel> PendingJyotishRecords { get; set; }
        public DbSet<UserModel> Users { get; set; }
        //public DbSet<UserTempModel> TempUser { get; set;  }
        public DbSet<AppointmentModel> AppointmentRecords { get; set; }
        public DbSet<TeamMemberModel> TeamMemberRecords { get; set; }
        public DbSet<PoojaModel> Pooja { get; set; }
        public DbSet<ExpertiseModel> ExpertiseRecords { get; set; } 
        public DbSet<CallingModel> CallingRecords { get; set; }
        public DbSet<ChattingModel> ChatingRecords { get; set; }

        public DbSet<PoojaRecordModel> PoojaRecord { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CallingModel>().HasOne(c => c.Jyotish).WithMany(j => j.CallingModelRecord).HasForeignKey(c => c.JyotishId);

            modelBuilder.Entity<CallingModel>().HasOne(c => c.User).WithMany(j => j.CallingModelRecord).HasForeignKey(c => c.UserId);

            modelBuilder.Entity<ChattingModel>().HasOne(c => c.Jyotish).WithMany(j => j.ChattingModelRecord).HasForeignKey(c => c.JyotishId);

            modelBuilder.Entity<ChattingModel>().HasOne(c => c.User).WithMany(j => j.ChattingModelRecord).HasForeignKey(c => c.UserId);
            modelBuilder.Entity<PoojaRecordModel>().HasOne(c => c.Jyotish).WithMany(j => j.PoojaModelRecord).HasForeignKey(c => c.JyotishId);

          /*  modelBuilder.Entity<Country>().HasMany(c => c.States).WithOne(s => s.Country).HasForeignKey(s => s.CountryId);
            modelBuilder.Entity<State>().HasMany(s => s.Cities).WithOne(c => c.State).HasForeignKey(c => c.StateId);*/
        }


    }

    
}
