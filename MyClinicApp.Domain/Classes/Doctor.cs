using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.Domain.Classes
{
    public class Doctor
    {
        public ulong ID { get; set; }
        public string FullName { get; set; }
        public Specialization Specialization { get; set; }
    }
}
