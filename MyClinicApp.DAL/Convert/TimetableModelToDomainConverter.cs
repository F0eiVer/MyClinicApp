using MyClinicApp.DAL.Models;
using MyClinicApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.Convert
{
    public static class TimetableModelToDomainConverter
    {
        public static Timetable ToDomain(this TimetableModel model)
        {
            return new Timetable
            {
                DoctorID = model.DoctorID,
                StartTime = model.StartTime,
                FinishTime = model.FinishTime,
            };
        }
    }
}
