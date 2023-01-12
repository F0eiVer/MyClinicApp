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
    public class TimetableRepository : ITimetableRepository
    {
        private readonly ApplicationDbContext db;

        public TimetableRepository(ApplicationDbContext _db)
        {
            db = _db;
        }

        public async Task<Timetable> Create(Timetable entity)
        {
            TimetableModel timetableModel = new TimetableModel()
            {
                DoctorID = entity.DoctorID,
                StartTime = entity.StartTime,
                FinishTime = entity.FinishTime,
            };

            await db.Timetables.AddAsync(timetableModel);
            await db.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(Timetable entity)
        {
            TimetableModel timetableModel = new TimetableModel()
            {
                DoctorID = entity.DoctorID,
                StartTime = entity.StartTime,
                FinishTime = entity.FinishTime,
            };

            db.Timetables.Remove(timetableModel);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<Timetable> Get(ulong id)
        {
            var timetableModel = await db.Timetables.FirstOrDefaultAsync(x => x.ID == id);
            return timetableModel.ToDomain();
        }

        public async Task<List<Timetable>> Select()
        {
            var timetableModels = await db.Timetables.ToListAsync();
            List<Timetable> timetables = new List<Timetable>();
            for (int i = 0; i < timetableModels.Count; i++)
            {
                timetables.Add(timetableModels[i].ToDomain());
            }
            return timetables;
        }

        public async Task<Timetable> GetDoctorTimetableOnDate(Doctor doctor, DateTime date)
        {
            var timetableModel = await db.Timetables.FirstOrDefaultAsync(x => x.Date == date && x.DoctorID == doctor.ID);
            return timetableModel.ToDomain();
        }

        public async Task<bool> AddDoctorTimetable(Timetable timetable)
        {
            TimetableModel timetableModel = new TimetableModel()
            {
                DoctorID = timetable.DoctorID,
                StartTime = timetable.StartTime,
                FinishTime = timetable.FinishTime,
            };

            await db.Timetables.AddAsync(timetableModel);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChangeDoctorTimetable(Doctor doctor, Timetable timetable)
        {
            var timetableModel = await db.Timetables.Where(x => x.DoctorID == doctor.ID).FirstOrDefaultAsync();
            timetableModel = new TimetableModel()
            {
                ID = timetableModel.ID,
                Date = timetableModel.Date,
                DoctorID = timetable.DoctorID,
                StartTime = timetable.StartTime,
                FinishTime = timetable.FinishTime,
            };
            await db.SaveChangesAsync();
            return true;
        }

    }
}
