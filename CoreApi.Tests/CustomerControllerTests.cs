using CoreApi.Controllers;
using CoreApi.Model;
using CoreApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CoreApi.Tests
{
    public class CustomerControllerTests
    {
        Mock<CustomerRepository> repoMock = new Mock<CustomerRepository>();

        [Fact]
        public async Task GetAllCustomersAsync_OnEmpty_ReturnsNotFound()
        {
            // Arrange
            repoMock.Setup(x => x.GetAllCustomers())
                .ReturnsAsync(Array.Empty<Customer>());

            CustomerController customerController = new CustomerController(repoMock.Object);

            // Action
            var actionResult = await customerController.GetAllCustomersAsync();

            // Assert
            Assert.IsType<NotFoundResult>(actionResult);
        }

        [Fact]
        public async Task GetAllCustomersAsync_OnSuccess_ReturnsListOfCustomers()
        {
            // Arrange
            Guid guid = Guid.NewGuid();

            Customer[] testCustomers = new Customer[]
                {
                    new Customer
                    {
                        Id = guid,
                        Name = "Test"
                    }
                };

            repoMock.Setup(x => x.GetAllCustomers())
                .ReturnsAsync(testCustomers);

            CustomerController customerController = new CustomerController(repoMock.Object);

            // Action
            var actionResult = await customerController.GetAllCustomersAsync();

            // Assert
            Assert.IsType<OkObjectResult>(actionResult);
            OkObjectResult okResult = (OkObjectResult)actionResult;

            Assert.Equal(okResult.Value, testCustomers);
        }

        [Fact]
        public async Task GetAllCustomersAsync_OnSuccess_InvokesOnlyOnce()
        {
            // Arrange
            CustomerController customerController = new CustomerController(repoMock.Object);

            // Act
            var actionResult = await customerController.GetAllCustomersAsync();

            // Assert
            repoMock.Verify(x => x.GetAllCustomers(), Times.Once());
        }
    }
}