using Microsoft.EntityFrameworkCore;
using MyClinicApp.DAL.Classes;
using MyClinicApp.DAL.Convert;
using MyClinicApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.Repositories
{
    public class TimetableRepository
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

    }
}
