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
        Task<User> GetUserByLogin(string login);

        Task<User> Create(UserParams userParams);

        Task<bool> HaveUserByLoginAndPassword(string login, string password);
    }
}
