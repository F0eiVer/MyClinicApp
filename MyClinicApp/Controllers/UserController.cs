using Microsoft.AspNetCore.Mvc;
using MyClinicApp.DAL.Interfaces;
using MyClinicApp.Service.Interfaces;
using System.Threading.Tasks;

namespace MyClinicApp.Controllers
{
    public class UserController : Controller 
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> GetUsers()
        {
            var response = await userService.GetUsers();
            return View(response.Data);
        }

    }
}
