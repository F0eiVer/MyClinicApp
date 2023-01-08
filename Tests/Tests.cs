using System;
using Xunit;
using Moq;
using MyClinicApp.DAL.Interfaces;
using MyClinicApp.Service.Implementations;
using MyClinicApp.Service.Interfaces;
using Castle.Components.DictionaryAdapter.Xml;
using MyClinicApp.Domain.Enum;
using MyClinicApp.Domain.Classes;

namespace UserTests
{
    public class UserTests
    {
        private readonly UserService userService;
        private readonly Mock<IUserRepository> userRepositoryMock;

        public UserTests()
        {
            userRepositoryMock = new Mock<IUserRepository>();
            userService = new UserService(userRepositoryMock.Object);
        }

        [Fact]
        public async void LoginIsEmptyOrNull()
        {
            var res = await userService.GetUserByLogin(string.Empty);

            Assert.True(res.StatusCode == StatusCode.DoesNotSetLogin);
            Assert.Equal("The user's login was not set.", res.Description);
        }

        [Fact]
        public async void UserNotFound()
        {
            userRepositoryMock.Setup(repository => repository.GetUserByLogin(It.IsAny<string>())).Returns(() => null);
            var res = await userService.GetUserByLogin("qwertyuiop");

            Assert.True(res.StatusCode == StatusCode.DoesNotFind);
            Assert.Equal("No user with this login was found.", res.Description);
        }

        [Fact]
        public async void CheckLoginIsEmptyOrNull()
        {
            var password = "123";
            var res = await userService.HaveUserByLoginAndPassword(string.Empty, password);

            Assert.True(res.StatusCode == StatusCode.DoesNotSetLogin);
            Assert.Equal("The user's login was not set.", res.Description);

            res = await userService.HaveUserByLoginAndPassword(string.Empty, string.Empty);

            Assert.True(res.StatusCode == StatusCode.DoesNotSetLogin);
            Assert.Equal("The user's login was not set.", res.Description);
        }

        [Fact]
        public async void PasswordIsEmptyOrNull()
        {
            var login = "123";
            var res = await userService.HaveUserByLoginAndPassword(login, string.Empty);

            Assert.True(res.StatusCode == StatusCode.DoesNotSetPassword);
            Assert.Equal("The user's password was not set.", res.Description);

        }

        [Fact]
        public async void CreateUserWithNull()
        {
            User user = null;
            var res = await userService.Create(user);

            Assert.True(res.StatusCode == StatusCode.DoesNotHaveImpl);
            Assert.Equal("There is no parameter for creating a user.", res.Description);

            UserParams userParams = null;
            res = await userService.Create(userParams);

            Assert.True(res.StatusCode == StatusCode.DoesNotHaveImpl);
            Assert.Equal("There is no parameter for creating a user.", res.Description);
        }

        [Fact]
        public async void DeleteUserWithNull()
        {
            User user = null;
            var res = await userService.Delete(user);

            Assert.True(res.StatusCode == StatusCode.DoesNotSetUser);
            Assert.Equal("No user is specified for deletion.", res.Description);

        }

        [Fact]
        public async void GetUserNotFound()
        {
            userRepositoryMock.Setup(repository => repository.Get(It.IsAny<ulong>())).Returns(() => null);
            var res = await userService.Get(23);

            Assert.True(res.StatusCode == StatusCode.DoesNotFind);
            Assert.Equal("The user was not found.", res.Description);
        }

    }
}
