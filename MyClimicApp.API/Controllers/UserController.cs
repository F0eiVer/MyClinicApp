using Microsoft.AspNetCore.Mvc;
using MyClimicApp.API.Views;
using MyClinicApp.Service.Implementations;
using System.Collections.Generic;
using MyClinicApp.Domain.Enum;
using System.Threading.Tasks;
using MyClinicApp.Domain.Classes;
using MyClinicApp.Domain.Response;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace MyClimicApp.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly UserService userService;

        public UserController(UserService _userService)
        {
            userService = _userService;
        }

        [Authorize]
        [HttpPost("userCreate")]
        public async Task<ActionResult<UserView>> Create(User user)
        {
            if (user.Equals(null))
            {
                return Problem(statusCode: 404, detail: "Не указан пользователь");
            }

            var userRes = await userService.Create(user);

            if(userRes.StatusCode != MyClinicApp.Domain.Enum.StatusCode.OK)
            {
                return Problem(statusCode: 404, detail: userRes.Description);
            }


            return Ok(new UserView
            {
                ID = userRes.Data.ID,
                PhoneNumber = userRes.Data.PhoneNumber,
                FullName = userRes.Data.FullName,
                Login = userRes.Data.Login,
                Role = userRes.Data.Role,
            });
        }

        [Authorize]
        [HttpPost("userParams")]
        public async Task<ActionResult<UserView>> Create(UserParams userParams)
        {
            if (userParams.Equals(null))
            {
                return Problem(statusCode: 404, detail: "Не указаны параметры пользователя");
            }

            var userRes = await userService.Create(userParams);
            if (userRes.Data.Equals(null))
            {
                return Problem(statusCode: 404, detail: userRes.Description);
            }

            return Ok(new UserView
            {
                ID = userRes.Data.ID,
                PhoneNumber = userRes.Data.PhoneNumber,
                FullName = userRes.Data.FullName,
                Login = userRes.Data.Login,
                Role = userRes.Data.Role,
            });
        }

        [Authorize]
        [HttpPost("userDelete")]
        public async Task<ActionResult<bool>> Delete(User user)
        {
            if (user.Equals(null))
            {
                return Problem(statusCode: 404, detail: "Не указан пользователь");
            }

            return Ok(await userService.Delete(user));
        }

        [HttpGet("userGet")]
        public async Task<ActionResult<UserView>> Get(ulong id)
        {
            var userRes = await userService.Get(id);
            if (userRes.Equals(null))
            {
                return Problem(statusCode: 404, detail: userRes.Description);
            }

            return Ok(new UserView
            {
                ID = userRes.Data.ID,
                PhoneNumber = userRes.Data.PhoneNumber,
                FullName = userRes.Data.FullName,
                Login = userRes.Data.Login,
                Role = userRes.Data.Role,
            });
        }

        [HttpGet("login")]
        public async Task<ActionResult<UserView>> GetUserByLogin(string login)
        {
            if(login == string.Empty)
            {
                return Problem(statusCode: 404, detail: "Не указан логин");
            }

            var userRes = await userService.GetUserByLogin(login);

            if(userRes.Data.Equals(null))
            {
                return Problem(statusCode: 404, detail: userRes.Description);
            }

            return Ok(new UserView
            {
                ID = userRes.Data.ID,
                PhoneNumber = userRes.Data.PhoneNumber,
                FullName = userRes.Data.FullName,
                Login = userRes.Data.Login,
                Role = userRes.Data.Role,
            });
        }

        [HttpGet("login_password")]
        public async Task<ActionResult<bool>> HaveUserByLoginAndPassword(string login, string password)
        {
            if (login == string.Empty)
            {
                return Problem(statusCode: 404, detail: "Не указан логин");
            }
            else if (password == string.Empty)
            {
                return Problem(statusCode: 404, detail: "Не указан пароль");
            }

            return Ok(await userService.HaveUserByLoginAndPassword(login, password));
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserView>>> GetUsers()
        {
            var users = await userService.GetUsers();
            if (users.Equals(null))
            {
                return Problem(statusCode: 404, detail: users.Description);
            }
            else if(users.Data.Count() == 0)
            {
                int t = (int)MyClinicApp.Domain.Enum.StatusCode.DoesNotFind;
                return Problem(statusCode: t, detail: users.Description);
            }

            List<UserView> usersRes = new List<UserView>();

            foreach(var user in users.Data)
            {
                usersRes.Add(new UserView
                {
                    ID = user.ID,
                    PhoneNumber = user.PhoneNumber,
                    FullName = user.FullName,
                    Login = user.Login,
                    Role = user.Role,
                });
            }

            return Ok(usersRes);
        }
    }
}
