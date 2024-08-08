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
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserTempModel> UserTemp { get; set;  }


    }
}
