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

namespace AppointmentTests
{
    public class AppointmentTests
    {
        private readonly AppointmentService appointmentService;
        private readonly Mock<IAppointmentRepository> appointmentRepositoryMock;

        public AppointmentTests()
        {
            appointmentRepositoryMock = new Mock<IAppointmentRepository>();
            appointmentService = new AppointmentService(appointmentRepositoryMock.Object);
        }

        [Fact]
        public async void SaveAppointmentWithNull()
        {
            var res = await appointmentService.SaveAppointment(null, new DateTime());

            Assert.True(res.StatusCode == StatusCode.DoesNotSetAppointment);
            Assert.Equal("Appointment is not specified for deletion.", res.Description);
        }

        [Fact]
        public async void GetFreeDatesWithNll()
        {
            var res = await appointmentService.GetFreeDatesBySpecialization(null);

            Assert.True(res.StatusCode == StatusCode.DoesNotSetSpecialization);
            Assert.Equal("Specialization is not specified for deletion.", res.Description);
        }

        [Fact]
        public async void GetFreeDatesNotFound()
        {
            var res = await appointmentService.GetFreeDatesBySpecialization(new Specialization());

            Assert.True(res.StatusCode == StatusCode.DoesNotFind);
            Assert.Equal("There are no dates with this specialization.", res.Description);
        }
    }
}
