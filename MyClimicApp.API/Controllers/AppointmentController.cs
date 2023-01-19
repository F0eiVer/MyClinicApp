using Microsoft.AspNetCore.Mvc;
using MyClinicApp.Domain.Classes;
using MyClinicApp.Domain.Response;
using MyClinicApp.Service.Implementations;
using System.Threading.Tasks;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using MyClinicApp.DAL.Models;
using MyClimicApp.API.Views;
using Microsoft.AspNetCore.Authorization;

namespace MyClimicApp.API.Controllers
{
    [ApiController]
    [Route("appointment")]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService appointmentService;

        public AppointmentController(AppointmentService _appointmentService)
        {
            appointmentService = _appointmentService;
        }

        [Authorize]
        [HttpPost("appointmentSave")]
        public async Task<ActionResult<bool>> SaveAppointment(Appointment appointment, DateTime date)
        {
            if (appointment.Equals(null))
            {
                int t = (int)MyClinicApp.Domain.Enum.StatusCode.DoesNotSetAppointment;
                return Problem(statusCode: t, detail: "Не указан прием");
            }

            var appointmentRes = await appointmentService.SaveAppointment(appointment, date);

            if (appointmentRes.Data.Equals(null))
            {
                int t = (int)appointmentRes.StatusCode;
                return Problem(statusCode: t, detail: appointmentRes.Description);
            }

            return Ok(true);
        }

        [HttpGet("freeDatesGet")]
        public async Task<ActionResult<IEnumerable<DateTime>>> GetFreeDatesBySpecialization(Specialization specialization)
        {
            if (specialization.Equals(null))
            {
                int t = (int)MyClinicApp.Domain.Enum.StatusCode.DoesNotSetSpecialization;
                return Problem(statusCode: t, detail: "Не указана специализация");
            }

            var dates = await appointmentService.GetFreeDatesBySpecialization(specialization);

            if(dates.Data.Count() == 0)
            {
                int t = (int)MyClinicApp.Domain.Enum.StatusCode.DoesNotFind;
                return Problem(statusCode: t, detail: dates.Description);
            }

            return Ok(dates);
        }
    }
}
