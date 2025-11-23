
using Microsoft.AspNetCore.Mvc;
using netCoreApi.Helpers;
using netCoreApi.Models;
using netCoreApi.Services;

namespace netCoreApi.Controllers
{
    public class UserController : BaseController
    {
        private UserService _userService;
        public UserController(UserService userService) 
        {
            _userService = userService; 
        }
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userService.TestSerilog();
        }

    }
}
