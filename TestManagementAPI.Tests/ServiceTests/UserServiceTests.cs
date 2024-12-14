using Microsoft.AspNetCore.Identity;
using Moq;
using MockQueryable.Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementAPI.Models;
using TaskManagementAPI.Services;
using Xunit;
using System.Linq;
using MockQueryable;

namespace TestManagementAPI.Tests.ServiceTests
{
    public class UserServiceTests
    {
        private readonly Mock<UserManager<User>> _userManagerMock;
        private readonly UserService _userService;
        private readonly List<User> _users;

        public UserServiceTests()
        {
            var userStore = new Mock<IUserStore<User>>();
            _userManagerMock = new Mock<UserManager<User>>(
                userStore.Object, null, null, null, null, null, null, null, null);

            _users = new List<User>
        {
            new User { Id = "1", UserName = "user1", Email = "user1@example.com", FullName = "User One" },
            new User { Id = "2", UserName = "user2", Email = "user2@example.com", FullName = "User Two" }
        };

            var userQueryable = _users.AsQueryable().BuildMock();

            _userManagerMock.Setup(u => u.Users).Returns(userQueryable);

            _userService = new UserService(_userManagerMock.Object);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetUsersAsync_ReturnsAllUsers()
        {
            // Act
            var result = await _userService.GetUsersAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("user1@example.com", result[0].Email);
            Assert.Equal("user2@example.com", result[1].Email);
        }
    }
}
