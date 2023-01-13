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
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository doctorRespository;

        public DoctorService(IDoctorRepository _doctorRepository)
        {
            doctorRespository = _doctorRepository;
        }

        public async Task<IBaseResponse<Doctor>> Create(Doctor doctor)
        {
            var baseResponse = new BaseResponse<Doctor>();
            try
            {
                if (doctor == null)
                {
                    baseResponse.Description = "Doctor is not specified for creation.";
                    baseResponse.StatusCode = StatusCode.DoesNotSetDoctor;

                    return baseResponse;
                }
                var res = await doctorRespository.Create(doctor);

                baseResponse.Data = res;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Doctor>()
                {
                    Description = $"[Create] : {ex.Message}",
                };
            }
        }

        public async Task<IBaseResponse<bool>> Delete(Doctor doctor)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                if (doctor == null)
                {
                    baseResponse.Description = "Doctor is not specified for deletion.";
                    baseResponse.StatusCode = StatusCode.DoesNotSetDoctor;
                    return baseResponse;
                }
                var res = await doctorRespository.Delete(doctor);

                baseResponse.Data = res;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[Delete] : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<Doctor>> Get(ulong id)
        {
            var baseResponse = new BaseResponse<Doctor>();
            try
            {
                var res = await doctorRespository.Get(id);
                if (res == null)
                {
                    baseResponse.Description = "The doctor was not found.";
                    baseResponse.StatusCode = StatusCode.DoesNotFind;
                    return baseResponse;
                }

                baseResponse.Data = res;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Doctor>()
                {
                    Description = $"[Get] : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Doctor>>> GetDoctors()
        {

            var baseResponse = new BaseResponse<IEnumerable<Doctor>>();
            try
            {
                var doctors = await doctorRespository.Select();
                if (doctors.Count == 0)
                {
                    baseResponse.Description = "There are no doctors in the database.";
                    baseResponse.StatusCode = StatusCode.DoesNotFind;
                    return baseResponse;
                }

                baseResponse.Data = doctors;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Doctor>>()
                {
                    Description = $"[GetDoctors] : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<Doctor>> GetDoctorBySpecialization(Specialization specialization)
        {
            var baseResponse = new BaseResponse<Doctor>();
            try
            {
                if(specialization == null)
                {
                    baseResponse.Description = "Does not set the specialization.";
                    baseResponse.StatusCode = StatusCode.DoesNotSetSpecialization;
                    return baseResponse;
                }

                var res = await doctorRespository.GetDoctorBySpecialization(specialization);

                if(res == null)
                {
                    baseResponse.Description = "The doctor with this specialization was not found.";
                    baseResponse.StatusCode = StatusCode.DoesNotFind;
                    return baseResponse;
                }

                baseResponse.Data = res;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Doctor>()
                {
                    Description = $"[GetDoctorBySpecialization] : {ex.Message}"
                };
            }
        }

    }
}
