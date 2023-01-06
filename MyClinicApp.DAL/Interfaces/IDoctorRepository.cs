using MyClinicApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.Interfaces
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Task<Doctor> GetDoctorBySpecialization(Specialization specialization);
                        
    }
}
