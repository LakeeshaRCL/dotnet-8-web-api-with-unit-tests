using DotnetWebApiUnitTesting.DTOs.Requests;
using DotnetWebApiUnitTesting.DTOs.Responses;
using DotnetWebApiUnitTesting.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetWebApiUnitTesting.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }




        [HttpPost]
        public BaseResponse CreateUser(CreateUserRequest request)
        {
            return userService.CreateUser(request);
        }

        [HttpGet]
        public BaseResponse ListUsers()
        {
            return userService.ListUsers();
        }

        [HttpGet("{id}")]
        public BaseResponse GetUser(long id)
        {
            return userService.GetUser(id);
        }


        [HttpGet("count")]
        public BaseResponse GetUserCount()
        {
            return userService.GetUserCount();
        }
    }
}
