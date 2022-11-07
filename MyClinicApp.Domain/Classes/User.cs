using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.Domain.Classes
{
    public class User
    {
        public ulong ID { get; set; }
        public ulong PhoneNumber { get; set; }
        public string FullName { get; set; }
        public Role Role { get; set; }
    }
}
