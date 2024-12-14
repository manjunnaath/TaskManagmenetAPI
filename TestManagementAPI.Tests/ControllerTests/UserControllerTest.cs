using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using TaskManagementAPI.Controllers;
using TaskManagementAPI.Models;
using Xunit;

namespace TestManagementAPI.Tests.ControllerTests
{

    

    public class UserControllerTests
    {
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            var userStore = new Mock<IUserStore<User>>();
            _userManagerMock = new Mock<UserManager<User>>(
                userStore.Object, null, null, null, null, null, null, null, null);

            _controller = new UserController(_userManagerMock.Object);
        }

        [Fact]
        public async System.Threading.Tasks.Task CreateUser_ReturnsOkResult_WhenUserIsCreated()
        {
            // Arrange
            var user = new User
            {
                UserName = "testuser",
                Email = "testuser@example.com",
                PasswordHash = "Password123!"
            };

            _userManagerMock.Setup(u => u.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                            .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _controller.CreateUser(user) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(user, result.Value);
        }

        [Fact]
        public async System.Threading.Tasks.Task CreateUser_ReturnsBadRequest_WhenUserCreationFails()
        {
            // Arrange
            var user = new User
            {
                UserName = "testuser",
                Email = "testuser@example.com",
                PasswordHash = "Password123!"
            };

            _userManagerMock.Setup(u => u.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                            .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Error creating user" }));

            // Act
            var result = await _controller.CreateUser(user) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }
    }


}
