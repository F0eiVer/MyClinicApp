﻿using Microsoft.AspNetCore.Mvc;
using MyClinicApp.Domain.Classes;
using MyClinicApp.Domain.Response;
using MyClinicApp.Service.Implementations;
using System.Threading.Tasks;
using System;
using MyClimicApp.API.Views;
using System.Numerics;
using Microsoft.AspNetCore.Authorization;

namespace MyClimicApp.API.Controllers
{
    [ApiController]
    [Route("timetable")]
    public class TimetableController : ControllerBase
    {
        private readonly TimetableService timetableService;

        public TimetableController(TimetableService _timetableService)
        {
            timetableService = _timetableService;
        }

        [HttpGet("timetableGet")]
        public async Task<ActionResult<Timetable>> GetDoctorTimetableOnDate(Doctor doctor, DateTime date)
        {
            if (doctor.Equals(null))
            {
                int t = (int)MyClinicApp.Domain.Enum.StatusCode.DoesNotSetDoctor;
                return Problem(statusCode: t, detail: "Не указан доктор");
            }

            var timetableRes = await timetableService.GetDoctorTimetableOnDate(doctor, date);

            if (timetableRes.Data.Equals(null))
            {
                int t = (int)MyClinicApp.Domain.Enum.StatusCode.DoesNotFind;
                return Problem(statusCode: t, detail: timetableRes.Description);
            }

            return Ok(new TimetableView
            {
                DoctorID = timetableRes.Data.DoctorID,
                StartTime = timetableRes.Data.StartTime,
                FinishTime = timetableRes.Data.FinishTime
            });
        }

        [Authorize]
        [HttpPost("timetableAdd")]
        public async Task<ActionResult<bool>> AddDoctorTimetable(Timetable timetable)
        {
            if (timetable.Equals(null))
            {
                int t = (int)MyClinicApp.Domain.Enum.StatusCode.DoesNotSetTimetable;
                return Problem(statusCode: t, detail: "Не указано расписание");
            }

            return Ok(await timetableService.AddDoctorTimetable(timetable));
        }

        [Authorize]
        [HttpPost("timetableChange")]
        public async Task<ActionResult<bool>> ChangeDoctorTimetable(DoctorAndTimetable doctorAndTimetable)
        {
            if (doctorAndTimetable.doctor.Equals(null))
            {
                int t = (int)MyClinicApp.Domain.Enum.StatusCode.DoesNotSetDoctor;
                return Problem(statusCode: t, detail: "Не указан доктор");
            }
            else if (doctorAndTimetable.timetable.Equals(null))
            {
                int t = (int)MyClinicApp.Domain.Enum.StatusCode.DoesNotSetTimetable;
                return Problem(statusCode: t, detail: "Не указано расписание");
            }

            return Ok(await timetableService.ChangeDoctorTimetable(doctorAndTimetable.doctor, doctorAndTimetable.timetable));
        }
    }
}
