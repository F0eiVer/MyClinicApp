using Moq;
using MyClinicApp.DAL.Interfaces;
using MyClinicApp.Domain.Classes;
using MyClinicApp.Domain.Enum;
using MyClinicApp.Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TimetableTests
{
    public class TimetableTests
    {
        private readonly TimetableService timetableService;
        private readonly Mock<ITimetableRepository> timetableRepositoryMock;

        public TimetableTests()
        {
            timetableRepositoryMock = new Mock<ITimetableRepository>();
            timetableService = new TimetableService(timetableRepositoryMock.Object);
        }

        [Fact]
        public async void GetDoctorTimetableWithNull()
        {
            DateTime dateTime = new DateTime(1, 1, 1, 1, 1, 1);
            var res = await timetableService.GetDoctorTimetableOnDate(null, dateTime);

            Assert.True(res.StatusCode == StatusCode.DoesNotSetDoctor);
            Assert.Equal("Doctor is not specified for deletion.", res.Description);

        }

        [Fact]
        public async void GetTimetableNotFound()
        {
            timetableRepositoryMock.Setup(repository => repository.GetDoctorTimetableOnDate(It.IsAny<Doctor>(), It.IsAny<DateTime>())).Returns(() => null);
            DateTime dateTime = new DateTime(1, 1, 1, 1, 1, 1);
            Doctor doctor = new Doctor();
            doctor.ID = 1;
            doctor.FullName = "Bob";
            var res = await timetableService.GetDoctorTimetableOnDate(doctor, dateTime);

            // NullReferenceExeprion It's Ok 
            Assert.Equal("[GetDoctorTimetableOnDate] : Object reference not set to an instance of an object.", res.Description);
        }

        [Fact]
        public async void AddDoctorTimetableWithNull()
        {
            var res = await timetableService.AddDoctorTimetable(null);

            Assert.True(res.StatusCode == StatusCode.DoesNotSetTimetable);
            Assert.Equal("Does not set the timetable.", res.Description);
        }

        [Fact]
        public async void ChangeDoctorTimetableWithNull()
        {
            var res = await timetableService.ChangeDoctorTimetable(null, new Timetable());

            Assert.True(res.StatusCode == StatusCode.DoesNotSetDoctor);
            Assert.Equal("Doctor is not specified for deletion.", res.Description);

            res = await timetableService.ChangeDoctorTimetable(new Doctor(), null);

            Assert.True(res.StatusCode == StatusCode.DoesNotSetTimetable);
            Assert.Equal("Does not set the timetable.", res.Description);
        }
    }
}
