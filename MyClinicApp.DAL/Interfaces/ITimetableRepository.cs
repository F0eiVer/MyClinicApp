using MyClinicApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.Interfaces
{
    public interface ITimetableRepository
    {
        Task<Timetable> GetDoctorTimetableOnDate(Doctor doctor, DateTime date);

        Task<bool> AddDoctorTimetable(Timetable timetable);

        Task<bool> ChangeDoctorTimetable(Doctor doctor, Timetable timetable);
    }
}
