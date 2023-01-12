using MyClinicApp.DAL.Models;
using MyClinicApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.Convert
{
    public static class AppointmentModelToDomainConverter
    {
        public static Appointment ToDomain(this AppointmentModel model)
        {
            return new Appointment
            {
                StartTime = model.StartTime,
                FinishTime = model.FinishTime,
                PatientID = model.PatientID,
                DoctorID = model.DoctorID,
            };
        }
    }
}
