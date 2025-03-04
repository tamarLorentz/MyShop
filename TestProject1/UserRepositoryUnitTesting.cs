using Entites;
using Moq;
using Repository;
using Moq.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class UserRepositoryUnitTesting
    {
        [Fact]
        public async Task GetUser_ValidCredentials_ReturnsUser()
        {
            // Arrange
            var user = new User
            {
                FirstName = "tamar",
                UserName = "test@gmail.com",
                Password = ",nr2155572"
            };
            var mockContext = new Mock<ApiManagerContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            var userResources = new UserRepository(mockContext.Object);

            // Act
            var result = await userResources.PostLogIn(user.UserName, user.Password);

            // Assert
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task GetUserById_ExistingId_ReturnsUser()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FirstName = "tamar",
                UserName = "test@gmail.com",
                Password = ",nr2155572"
            };
            var mockContext = new Mock<ApiManagerContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            var userResources = new UserRepository(mockContext.Object);

            // Act
            var result = await userResources.Get(user.Id);

            // Assert
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task PostUser_ValidUser_ReturnsUser()
        {
            // Arrange
            var user = new User
            {
                FirstName = "tamar",
                UserName = "test@gmail.com",
                Password = ",nr2155572"
            };
            var mockContext = new Mock<ApiManagerContext>();
            mockContext.Setup(x => x.Users.AddAsync(user, default)).ReturnsAsync(new Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<User>(null));
            var userResources = new UserRepository(mockContext.Object);

            // Act
            var result = await userResources.Post(user);

            // Assert
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task PutUser_ValidUser_ReturnsUpdatedUser()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                FirstName = "tamar",
                UserName = "test@gmail.com",
                Password = ",nr2155572"
            };
            var mockContext = new Mock<ApiManagerContext>();
            mockContext.Setup(x => x.Users.Update(user));
            var userResources = new UserRepository(mockContext.Object);

            // Act
            var result = await userResources.Put(user.Id, user);

            // Assert
            Assert.Equal(user, result);
        }

    //    [Fact]
    //    public void CheckPassword_ValidPassword_ReturnsStrength()
    //    {
    //        // Arrange
    //        var password = ",nr2155572";
    //        var mockContext = new Mock<ApiManagerContext>();
    //        var userResources = new UserRepository(mockContext.Object);

    //        // Act
    //        var result = userResources.CheckPassword(password);

    //        // Assert
    //        Assert.Equal(3, result); // Assuming 3 is the expected strength for the given password
    //    }
    //}
}
    }
