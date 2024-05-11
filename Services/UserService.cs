using DotnetWebApiUnitTesting.DTOs.Requests;
using DotnetWebApiUnitTesting.DTOs.Responses;
using DotnetWebApiUnitTesting.Models;

namespace DotnetWebApiUnitTesting.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
            // constructor
        }


        public BaseResponse CreateUser(CreateUserRequest request)
        {
            try
            {
                using(ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    UserModel newUser = new UserModel(request);
                    dbContext.User.Add(newUser);
                    dbContext.SaveChanges();

                    return new BaseResponse(StatusCodes.Status200OK, "Successfully created");
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        public BaseResponse ListUsers() {
           
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    List<UserModel> users = dbContext.User.ToList();
                    return new BaseResponse(StatusCodes.Status200OK, users);
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        public BaseResponse GetUser(long id)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    UserModel? user = dbContext.User.Where(u => u.id == id).FirstOrDefault();
                    return new BaseResponse(StatusCodes.Status200OK, user);
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        public BaseResponse GetUserCount()
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    int count = dbContext.User.Count(); 
                    return new BaseResponse(StatusCodes.Status200OK, count);
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
