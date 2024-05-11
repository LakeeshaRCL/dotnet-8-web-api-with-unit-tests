using DotnetWebApiUnitTesting.DTOs.Requests;
using DotnetWebApiUnitTesting.DTOs.Responses;

namespace DotnetWebApiUnitTesting.Services
{
    public interface IUserService
    {
        BaseResponse CreateUser(CreateUserRequest request);
        BaseResponse ListUsers();
        BaseResponse GetUser(long id);
        BaseResponse GetUserCount();

    }
}
