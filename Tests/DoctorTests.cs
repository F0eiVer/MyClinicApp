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

namespace DoctorTests
{
    public class DoctorTests
    {
        private readonly DoctorService doctorService;
        private readonly Mock<IDoctorRepository> doctorRepositoryMock;

        public DoctorTests()
        {
            doctorRepositoryMock = new Mock<IDoctorRepository>();
            doctorService = new DoctorService(doctorRepositoryMock.Object);
        }

        [Fact]
        public async void CreateDoctorWithNull()
        {
            var res = await doctorService.Create(null);

            Assert.True(res.StatusCode == StatusCode.DoesNotSetDoctor);
            Assert.Equal("Doctor is not specified for creation.", res.Description);
        }

        [Fact]
        public async void DeleteDoctorWithNull()
        {
            Doctor doctor = null;
            var res = await doctorService.Delete(doctor);

            Assert.True(res.StatusCode == StatusCode.DoesNotSetDoctor);
            Assert.Equal("Doctor is not specified for deletion.", res.Description);

        }

        [Fact]
        public async void GetUserNotFound()
        {
            doctorRepositoryMock.Setup(repository => repository.Get(It.IsAny<ulong>())).Returns(() => null);
            var res = await doctorService.Get(23);

            Assert.True(res.StatusCode == StatusCode.DoesNotFind);
            Assert.Equal("The doctor was not found.", res.Description);
        }

        [Fact]
        public async void SpecializationNull()
        {
            var res = await doctorService.GetDoctorBySpecialization(null);

            Assert.True(res.StatusCode == StatusCode.DoesNotSetSpecialization);
            Assert.Equal("Does not set the specialization.", res.Description);
        }

    }
}
