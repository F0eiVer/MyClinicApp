using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClinicApp.Domain.Response;
using MyClinicApp.Domain.Classes;

namespace MyClinicApp.Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<IEnumerable<User>>> GetUsers();
    }
}
