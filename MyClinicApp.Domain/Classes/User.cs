using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.Domain.Classes
{

    public class UserParams
    {
        public string Password { get; set; }
        public ulong ID { get; set; }
        public ulong PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public Role Role { get; set; }
    }
    public class User
    {
        private string Password;
        public ulong ID { get; set; }
        public ulong PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public Role Role { get; set; }

        public User(string _Passord, ulong _ID, string _FullName, string _Login, ulong _PhoneNumber = 0, Role _Role = null)
        {
            Password = _Passord;
            ID = _ID;
            PhoneNumber = _PhoneNumber;
            FullName = _FullName;
            Login = _Login;
            Role = _Role;
        }
        public User(UserParams userParams)
        {
            Password = userParams.Password;
            ID = userParams.ID;
            PhoneNumber = userParams.PhoneNumber;
            FullName = userParams.FullName;
            Login = userParams.Login;
            Role = userParams.Role;
        }
    }
}
