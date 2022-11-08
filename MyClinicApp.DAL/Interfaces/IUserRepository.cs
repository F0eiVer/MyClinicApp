using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinicApp.Domain.Classes;

namespace MyClinicApp.DAL.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserByLogin(string login);

        bool HaveUserByLoginAndPassword(string login, string password);
    }
}
