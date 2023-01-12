using MyClinicApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.Models
{
    public class UserModel
    {
        public string Password { get; set; }
        public ulong ID { get; set; }
        public ulong PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public Role Role { get; set; }
    }
}
