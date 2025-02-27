using Entites;
using Moq;
using Resources;
using Moq.EntityFrameworkCore;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class UserRepositoryUnitTesting
    {
        [Fact]
        public async Task GetUser_ValidCredentials_ReturnsUser()
        {
            //arrange
            var user = new User
            {
                FirstName = "tamar",
                UserName = "test@gmail.com",
                Password = ",nr2155572"
            };
            var mockContext = new Mock<ApiManagerContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            var userResources = new UserResources(mockContext.Object);
            //act
            var result = await userResources.PostLogIn(user.UserName, user.Password);
            //asert
            Assert.Equal(user, result);
        } 
    }
}
