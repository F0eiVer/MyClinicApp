using Microsoft.EntityFrameworkCore;
using MyClinicApp.DAL.Models;
using MyClinicApp.DAL.Convert;
using MyClinicApp.DAL.DBContext;
using MyClinicApp.DAL.Interfaces;
using MyClinicApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext db;

        public AppointmentRepository(ApplicationDbContext _db)
        {
            db = _db;
        }

        public async Task<Appointment> Create(Appointment entity)
        {
            AppointmentModel appointmentModel = new AppointmentModel()
            {
                StartTime = entity.StartTime,
                FinishTime = entity.FinishTime,
                DoctorID = entity.DoctorID,
                PatientID = entity.PatientID,
            };

            await db.Appointments.AddAsync(appointmentModel);
            await db.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(Appointment entity)
        {
            AppointmentModel appointmentModel = new AppointmentModel()
            {
                StartTime = entity.StartTime,
                FinishTime = entity.FinishTime,
                DoctorID = entity.DoctorID,
                PatientID = entity.PatientID,
            };

            db.Appointments.Remove(appointmentModel);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<Appointment> Get(ulong id)
        {
            var appointmentModel = await db.Appointments.FirstOrDefaultAsync(x => x.ID == id);
            return appointmentModel.ToDomain();
        }

        public async Task<List<Appointment>> Select()
        {
            var appointmentModels = await db.Appointments.ToListAsync();
            List<Appointment> appointments = new List<Appointment>();
            for (int i = 0; i < appointmentModels.Count; i++)
            {
                appointments.Add(appointmentModels[i].ToDomain());
            }
            return appointments;
        }

        public async Task<bool> SaveAppointment(Appointment appointment, DateTime date)
        {
            AppointmentModel appointmentModel = new AppointmentModel()
            {
                Date = date,
                StartTime = appointment.StartTime,
                FinishTime = appointment.FinishTime,
                DoctorID = appointment.DoctorID,
                PatientID = appointment.PatientID,
            };

            await db.Appointments.AddAsync(appointmentModel);
            await db.SaveChangesAsync();

            return true;
        }

    }
}
