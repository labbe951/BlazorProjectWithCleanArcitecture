using AutoMapper;
using CentiroHomeAssignment.Services;
using CentiroHomeAssignment.Services.Features.Files;
using CentiroHomeAssignment.Services.Features.Orders;
using CentiroHomeAssignment.Shared.IRepositories;
using CentiroHomeAssignment.Shared.Models;
using CentiroHomeAssignment.Shared.ResponseModels;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Xunit;
using System.Data;

namespace CentiroHomeAssignment.Tests
{
    public class OrderServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IFileService> _mockFileService;

        public OrderServiceTests()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockFileService = new Mock<IFileService>();

            _mockOrderRepository.Setup(orderRepo => orderRepo.GetAllOrders()).ReturnsAsync(new List<Order>());
            _mockOrderRepository.Setup(orderRepo => orderRepo.AddRangeAsync(It.IsAny<List<Order>>())).ReturnsAsync(new List<Order>());


            
        }

        [Fact]
        public async Task GetAllOrdersShouldCallGetAllOrdersOnce()
        {
            //Arrange
            //Act
            var sut = new OrderService(_mockOrderRepository.Object, _mapper, _mockFileService.Object);
            var result = await sut.GetAllOrders();

            //Assert
            _mockOrderRepository.Verify(orderRepository => orderRepository.GetAllOrders(), Times.Once());
        }

        [Fact]
        public async Task GetAllOrdersShouldReturnOrderResponses()
        {
            //Arrange
            _mockOrderRepository.Setup(orderRepository => orderRepository.GetAllOrders());
            //Act
            var sut = new OrderService(_mockOrderRepository.Object, _mapper, _mockFileService.Object);
            var result = await sut.GetAllOrders();
            //Assert
            result.ShouldBeOfType<List<OrderResponse>>();
        }

        [Fact]
        public async Task ImportOrdersShouldCallConvertCSVtoDataTableOnce()
        {
            //Arrange

            //Act
            var sut = new OrderService(_mockOrderRepository.Object, _mapper, _mockFileService.Object);
            await sut.ImportOrders(It.IsAny<string>());
            //Assert
            _mockFileService.Verify(fileServ => fileServ.ConvertCSVtoDataTable(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ImportOrdersShouldCallDataTableToListOfOrderRequestsAsyncOnce()
        {
            //Arrange

            //Act
            var sut = new OrderService(_mockOrderRepository.Object, _mapper, _mockFileService.Object);
            await sut.ImportOrders(It.IsAny<string>());
            //Assert
            _mockFileService.Verify(fileServ => fileServ.DataTableToListOfOrderRequestsAsync(It.IsAny<DataTable>()), Times.Once);
        }

        [Fact]
        public async Task ImportOrdersShouldCallAddRangeAsyncOnce()
        {
            //Arrange

            //Act
            var sut = new OrderService(_mockOrderRepository.Object, _mapper, _mockFileService.Object);
            await sut.ImportOrders(It.IsAny<string>());
            //Assert
            _mockOrderRepository.Verify(orderRepository => orderRepository.AddRangeAsync(It.IsAny<List<Order>>()), Times.Once());
        }
    }
}
