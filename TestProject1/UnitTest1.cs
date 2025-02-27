using System.Reflection.Metadata;
using Entites;
using Moq;
using Moq.EntityFrameworkCore;
using Resources;


namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetUser_ValidCredentials_ReturnsUser()
        {
            //Arrange
            var user = new User { FirstName = "Rut", UserName = "test@test.test", Password = ")(*fkjl123" };

            var mockContext = new Mock<ApiManagerContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserResources(mockContext.Object);

            //Act 
            var result = await userRepository.PostLogIn(user.UserName, user.Password);

            //Assert
            Assert.Equal(user, result);
        }
    }

}