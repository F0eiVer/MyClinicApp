using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.Domain.Classes
{

    public class UserParams
    {
        public string passord { get; set; }
        public ulong ID { get; set; }
        public ulong PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public Role Role { get; set; }
    }
    public class User
    {
        private string Passord;
        public ulong ID { get; set; }
        public ulong PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public Role Role { get; set; }

        public User(string passord, ulong iD, string fullName, string login, ulong phoneNumber = 0, Role role = null)
        {
            Passord = passord;
            ID = iD;
            PhoneNumber = phoneNumber;
            FullName = fullName;
            Login = login;
            Role = role;
        }
        public User(UserParams userParams)
        {
            Passord = userParams.passord;
            ID = userParams.ID;
            PhoneNumber = userParams.PhoneNumber;
            FullName = userParams.FullName;
            Login = userParams.Login;
            Role = userParams.Role;
        }
    }
}
