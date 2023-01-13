using Microsoft.AspNetCore.Mvc;
using MyClinicApp.Service.Implementations;

namespace MyClimicApp.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService _userService)
        {
            userService = _userService;
        }
    }
}
