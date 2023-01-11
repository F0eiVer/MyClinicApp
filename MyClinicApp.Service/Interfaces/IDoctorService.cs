using MyClinicApp.Domain.Classes;
using MyClinicApp.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.Service.Interfaces
{
    public interface IDoctorService
    {
        Task<IBaseResponse<IEnumerable<Doctor>>> GetDoctors();
    }
}
