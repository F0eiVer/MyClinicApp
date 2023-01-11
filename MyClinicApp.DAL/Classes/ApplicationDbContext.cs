using Microsoft.EntityFrameworkCore;
using MyClinicApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.Classes
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Appointment>? Appointments { get; set; }

        public DbSet<Doctor>? Doctors { get; set; }

        public DbSet<Role>? Roles { get; set; }

        public DbSet<Specialization>? Specializations { get; set; }

        public DbSet<TimeTable>? TimeTables { get; set; }

        public DbSet<User>? Users { get; set; }
    }
}
