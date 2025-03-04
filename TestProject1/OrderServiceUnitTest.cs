using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Repository;
using Xunit;
using Entites;
using Services;

namespace TestProject1
{
    public class OrderServiceUnitTesting
    {
        [Fact]
        public async Task Post_ValidOrder_ReturnsOrder()
        {
            // Arrange
            var product = new Product { Id = 1, Price = 10.0 };
            var orderItem = new OrderItem { ProuductId = 1, Quantity = 2 };
            var order = new Order { OrderItems = new List<OrderItem> { orderItem }, Sum = 20.0 };

            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(repo => repo.Get(null, null, new int?[0], null))
                .ReturnsAsync(new List<Product> { product });

            var mockOrderRepository = new Mock<IOrderRepository>();
            mockOrderRepository.Setup(repo => repo.Post(order)).ReturnsAsync(order);

            var mockLogger = new Mock<ILogger<OrderServices>>(); // updated to ILogger<OrderServices>
            var service = new OrderServices(mockOrderRepository.Object, mockProductRepository.Object, mockLogger.Object); // updated to OrderServices

            // Act
            var result = await service.Post(order); // updated to service.Post

            // Assert
            Assert.NotNull(result);
            Assert.Equal(20.0, result.Sum);
            mockLogger.Verify(
                x => x.Log(
                    LogLevel.Critical,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("somone try to change the order sum")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Never);
        }

        [Fact]
        public async Task Post_InvalidOrderSum_ChangesSumAndLogsCritical()
        {
            // Arrange
            var product = new Product { Id = 1, Price = 10.0 };
            var orderItem = new OrderItem { ProuductId = 1, Quantity = 2 };
            var order = new Order { OrderItems = new List<OrderItem> { orderItem }, Sum = 15.0 };

            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(repo => repo.Get(null, null, new int?[0], null))
                .ReturnsAsync(new List<Product> { product });

            var mockOrderRepository = new Mock<IOrderRepository>();
            mockOrderRepository.Setup(repo => repo.Post(order)).ReturnsAsync(order);

            var mockLogger = new Mock<ILogger<OrderServices>>(); // updated to ILogger<OrderServices>
            var service = new OrderServices(mockOrderRepository.Object, mockProductRepository.Object, mockLogger.Object); // updated to OrderServices

            // Act
            var result = await service.Post(order); // updated to service.Post

            // Assert
            Assert.NotNull(result);
            Assert.Equal(20.0, result.Sum);
            mockLogger.Verify(
                x => x.Log(
                    LogLevel.Critical,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("somone try to change the order sum")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }
    }
}