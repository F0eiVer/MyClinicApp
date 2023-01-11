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
    public class TimetableService : ITimetableService
    {
        private readonly ITimetableRepository timetableRespository;

        public TimetableService(ITimetableRepository _timetableRespository)
        {
            timetableRespository = _timetableRespository;
        }

        public async Task<IBaseResponse<Timetable>> GetDoctorTimetableOnDate(Doctor doctor, DateTime date)
        {
            var baseResponse = new BaseResponse<Timetable>();
            try
            {
                if (doctor == null)
                {
                    baseResponse.Description = "Doctor is not specified for deletion.";
                    baseResponse.StatusCode = StatusCode.DoesNotSetDoctor;
                    return baseResponse;

                }
                var res = await timetableRespository.GetDoctorTimetableOnDate(doctor, date);

                if (res == null)
                {
                    baseResponse.Description = "Does not find doctor's timetable with such date.";
                    baseResponse.StatusCode = StatusCode.DoesNotFind;
                    return baseResponse;
                }

                baseResponse.Data = res;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Timetable>()
                {
                    Description = $"[GetDoctorTimetableOnDate] : {ex.Message}"
                };
            }
            
        }

        public async Task<IBaseResponse<bool>> AddDoctorTimetable(Timetable timetable)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                if (timetable == null)
                {
                    baseResponse.Description = "Does not set the timetable.";
                    baseResponse.StatusCode = StatusCode.DoesNotSetTimetable;
                    return baseResponse;
                }

                var res = await timetableRespository.AddDoctorTimetable(timetable);

                baseResponse.Data = res;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[AddDoctorTimetable] : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<bool>> ChangeDoctorTimetable(Doctor doctor, Timetable timetable)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                if (doctor == null)
                {
                    baseResponse.Description = "Doctor is not specified for deletion.";
                    baseResponse.StatusCode = StatusCode.DoesNotSetDoctor;
                    return baseResponse;

                } else if (timetable == null) {

                    baseResponse.Description = "Does not set the timetable.";
                    baseResponse.StatusCode = StatusCode.DoesNotSetTimetable;
                    return baseResponse;
                }

                var res = await timetableRespository.ChangeDoctorTimetable(doctor, timetable);

                baseResponse.Data = res;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[ChangeDoctorTimetable] : {ex.Message}"
                };
            }
        }
    }
}
