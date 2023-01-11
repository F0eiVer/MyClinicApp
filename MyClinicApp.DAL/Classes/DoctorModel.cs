using MyClinicApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.Classes
{
    public class DoctorModel
    {
        public ulong ID { get; set; }
        public string FullName { get; set; }
        public Specialization Specialization { get; set; }
    }
}
