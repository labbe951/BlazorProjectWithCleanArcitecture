using AutoMapper;
using CentiroHomeAssignment.Services.Features.Files;
using CentiroHomeAssignment.Shared.IRepositories;
using CentiroHomeAssignment.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Services.Features.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IFileService fileService)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        // Används inte, kan vara bra att ha.
        public async Task<OrderResponse> GetOrderByOrderNo(int orderNo)
        {
            var order = await _orderRepository.GetByOrderNo(orderNo);
            var orderResponse = _mapper.Map<OrderResponse>(order);
            return orderResponse;
        }

        public async Task<List<OrderResponse>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();
            var orderResponses = _mapper.Map<List<OrderResponse>>(orders);
            return orderResponses;
        }

        public async Task ImportOrders(string filePath) 
        {
            var readFile = _fileService.ConvertCSVtoDataTable(filePath);

            var order = await _fileService.DataTableToListOfOrderRequestsAsync(readFile);

            await _orderRepository.AddRangeAsync(order);
        }
    }
}
