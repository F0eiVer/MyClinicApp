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

        public DbSet<UserModel>? Users { get; set; }

        public DbSet<DoctorModel>? Doctors { get; set; }

        public DbSet<TimetableModel>? Timetables { get; set; }

        public DbSet<AppointmentModel>? Appointments { get; set; }

    }
}
