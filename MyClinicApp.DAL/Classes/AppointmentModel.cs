using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.Classes
{
    public class AppointmentModel
    {
        public uint ID { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
        public ulong PatientID { get; set; }
        public ulong DoctorID { get; set; }
    }
}
