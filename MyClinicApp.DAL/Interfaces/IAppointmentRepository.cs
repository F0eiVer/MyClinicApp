using MyClinicApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.DAL.Interfaces
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        Task<bool> SaveAppointment(Appointment appointment, DateTime date);
        //will use date.ToShortDateString() to receive the date without time

    }
}
