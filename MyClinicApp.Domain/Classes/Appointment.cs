using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.Domain.Classes
{
    public class Appointment
    {
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public ulong PatientID { get; set; }
        public ulong DoctorID { get; set; }
    }
}
