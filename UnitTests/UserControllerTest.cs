using DotnetWebApiUnitTesting.Controllers;
using DotnetWebApiUnitTesting.DTOs.Responses;
using DotnetWebApiUnitTesting.Models;
using DotnetWebApiUnitTesting.Services;
using Microsoft.AspNetCore.Http;
using Moq;

namespace UnitTests;

public class UserControllerTest
{
    private Mock<IUserService> userServiceMock;

    public UserControllerTest()
    {
        userServiceMock = new Mock<IUserService>(); 
    }

    [Fact]
    public void TestGetUsers()
    {

        // 1.Arrange

        // define output from the service
        List<UserModel> users = new List<UserModel> {
            new UserModel {
                id = 1,
                name = "Sam Zampla",
                email = "sam@abc.com",
                contactNumber = "254678311",
                address = "Main street, Town B, LA",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            },
            new UserModel {
                id = 2,
                name = "Will Williams",
                email = "will@abc.com",
                contactNumber = "75634512",
                address = "Main street 2, Town C, LA",
                createdAt = DateTime.Now,
                updatedAt = DateTime.Now
            }
        };

        // return type of UserService's ListUsers() method
        BaseResponse listUsersBaseResponse = new BaseResponse(StatusCodes.Status200OK, users);
        userServiceMock.Setup(um => um.ListUsers()).Returns(listUsersBaseResponse);

        // define controller using mocked service
        UserController userController = new UserController(userServiceMock.Object);

        // 2. Act

        var userListResponse = userController.ListUsers();


        // 3. Assert

        // test response type
        Assert.IsType<BaseResponse>(userListResponse);

        // test response status code
        Assert.Equal(200, userListResponse.statusCode);

        // test response data type
        Assert.IsType<List<UserModel>>(userListResponse.data);

    }


    [Theory]
    [InlineData(1)]
    public void TestGetUser(long id)
    {
        // 1.Arrange

        // define output from the service
        UserModel user = new UserModel
        {
            id = 1,
            name = "Sam Zampla",
            email = "sam@abc.com",
            contactNumber = "254678311",
            address = "Main street, Town B, LA",
            createdAt = DateTime.Now,
            updatedAt = DateTime.Now
        };

        // return type of UserService's GetUser() method
        BaseResponse getUserBaseResponse = new BaseResponse(StatusCodes.Status200OK, user);
        userServiceMock.Setup(um => um.GetUser(id)).Returns(getUserBaseResponse);

        // define controller using mocked service
        UserController userController = new UserController(userServiceMock.Object);

        // 2. Act

        var getUserResponse = userController.GetUser(id);


        // 3. Assert

        // test response type
        Assert.IsType<BaseResponse>(getUserResponse);

        // test response status code
        Assert.Equal(200, getUserResponse.statusCode);

        // test response data type
        Assert.IsType<UserModel>(getUserResponse.data);

    }


    [Fact(DisplayName = "Get User Count Should Return User Data Count When Data Available")]
    public void TestGetUserCount()
    {

        // 1.Arrange

        // define output from the service

        // return type of UserService's GetUserCount() method
        BaseResponse getUserCountBaseResponse = new BaseResponse(StatusCodes.Status200OK, 2);
        userServiceMock.Setup(um => um.GetUserCount()).Returns(getUserCountBaseResponse);

        // define controller using mocked service
        UserController userController = new UserController(userServiceMock.Object);

        // 2. Act

        var getUserCountResponse = userController.GetUserCount();


        // 3. Assert

        // test response type
        Assert.IsType<BaseResponse>(getUserCountResponse);

        // test response status code
        Assert.Equal(200, getUserCountResponse.statusCode);

        // test response data type
        Assert.IsType<int>(getUserCountResponse.data);

        // test value is greater than zero
        Assert.True((int)getUserCountResponse.data > 0);

    }
}