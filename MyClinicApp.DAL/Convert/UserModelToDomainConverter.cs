using MyClinicApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.Classes
{
    public static class UserModelToDomainConverter
    {
        public static User ToDomain(this UserModel model)
        {
            return new User
            {
                Password = model.Password,
                ID = model.ID,
                PhoneNumber = model.PhoneNumber,
                FullName = model.FullName,
                Login = model.Login,
                Role = model.Role
            };
        }
    }
}
