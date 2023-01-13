using Microsoft.EntityFrameworkCore;
using MyClinicApp.DAL.DBContext;
using MyClinicApp.DAL.Interfaces;
using MyClinicApp.DAL.Repositories;
using MyClinicApp.Domain.Classes;
using MyClinicApp.Domain.Enum;
using MyClinicApp.Domain.Response;
using MyClinicApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicApp.Service.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository appointmentRespository;
        private readonly ApplicationDbContext db;

        public AppointmentService(IAppointmentRepository _appointmentRepository)
        {
            appointmentRespository = _appointmentRepository;
        }

        public async Task<IBaseResponse<bool>> SaveAppointment(Appointment appointment, DateTime date)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                if(appointment == null)
                {
                    baseResponse.Description = "Appointment is not specified for deletion.";
                    baseResponse.StatusCode = StatusCode.DoesNotSetAppointment;

                    return baseResponse;
                }

                var res = await appointmentRespository.SaveAppointment(appointment, date);

                if(res == false)
                {
                    baseResponse.Description = "This date is taken.";
                    baseResponse.StatusCode = StatusCode.TakenDate;

                    return baseResponse;
                }

                baseResponse.Data = res;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[SaveAppointment] : {ex.Message}",
                };
            }
        }
        
        public async Task<IBaseResponse<IEnumerable<DateTime>>> GetFreeDatesBySpecialization(Specialization specialization)
        {
            var baseResponse = new BaseResponse<IEnumerable<DateTime>>();
            
            try
            {
                if (specialization == null)
                {
                    baseResponse.Description = "Specialization is not specified for deletion.";
                    baseResponse.StatusCode = StatusCode.DoesNotSetSpecialization;

                    return baseResponse;
                }
                var doctors = await db.Doctors.Where(x => x.Specialization == specialization).ToListAsync();

                if(doctors.Count == 0)
                {
                    baseResponse.Description = "There are no doctors with this specialization.";
                    baseResponse.StatusCode = StatusCode.DoesNotFind;
                    return baseResponse;
                }

                var res = await db.Appointments.Where(x => x.PatientID.Equals(null)).ToListAsync();

                if(res.Count == 0)
                {
                    baseResponse.Description = "There are no free date for this specialization.";
                    baseResponse.StatusCode = StatusCode.DoesNotFind;
                    return baseResponse;
                }

                List<DateTime> dates = new List<DateTime>();
                for(int i=0; i<res.Count; i++)
                {
                    dates.Add(res[i].Date);
                }

                baseResponse.Data = dates;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<IEnumerable<DateTime>>()
                {
                    Description = $"[GetFreeDatesBySpecialization] : {ex.Message}",
                };
            }
        }
        
    }
}
