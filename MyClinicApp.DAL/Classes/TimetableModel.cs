using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.Classes
{
    public class TimetableModel
    {
        public uint ID { get; set; }
        public uint DoctorID { get; set; }
        public string StartTime { get; set; }
        public string FinishTime { get; set; }
    }
}
