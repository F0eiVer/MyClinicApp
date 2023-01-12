using Microsoft.EntityFrameworkCore;
using MyClinicApp.DAL.Models;
using MyClinicApp.DAL.Convert;
using MyClinicApp.DAL.Interfaces;
using MyClinicApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinicApp.DAL.DBContext;

namespace MyClinicApp.DAL.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext db;

        public DoctorRepository(ApplicationDbContext _db)
        {
            db = _db;
        }

        public async Task<Doctor> Create(Doctor entity)
        {
            DoctorModel doctorModel = new DoctorModel()
            {
                ID = entity.ID,
                FullName = entity.FullName,
                Specialization = entity.Specialization,
            };

            await db.Doctors.AddAsync(doctorModel);
            await db.SaveChangesAsync();

            return entity;
        }
        
        public async Task<bool> Delete(Doctor entity)
        {
            DoctorModel doctorModel = new DoctorModel()
            {
                ID = entity.ID,
                FullName = entity.FullName,
                Specialization = entity.Specialization,
            };

            db.Doctors.Remove(doctorModel);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<Doctor> Get(ulong id)
        {
            var doctorModel = await db.Doctors.FirstOrDefaultAsync(x => x.ID == id);
            return doctorModel.ToDomain();
        }

        public async Task<List<Doctor>> Select()
        {
            var doctorModels = await db.Doctors.ToListAsync();
            List<Doctor> doctors = new List<Doctor>();
            for (int i = 0; i < doctorModels.Count; i++)
            {
                doctors.Add(doctorModels[i].ToDomain());
            }
            return doctors;
        }

        public async Task<Doctor> GetDoctorBySpecialization(Specialization specialization)
        {
            var doctorModel = await db.Doctors.FirstOrDefaultAsync(x => x.Specialization == specialization);
            return doctorModel.ToDomain();
        }

    }
}
