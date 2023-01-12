using MyClinicApp.DAL.Models;
using MyClinicApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.Convert
{
    public static class DoctorModelToDomainConverter
    {
        public static Doctor ToDomain(this DoctorModel model)
        {
            return new Doctor
            {
                ID = model.ID,
                FullName = model.FullName,
                Specialization = model.Specialization,
            };
        }
    }
}
