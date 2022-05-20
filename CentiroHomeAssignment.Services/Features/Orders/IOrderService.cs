using CentiroHomeAssignment.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Services.Features.Orders
{
    public interface IOrderService
    {
        Task<OrderResponse> GetOrderByOrderNo(int orderNo);
        Task<List<OrderResponse>> GetAllOrders();
        Task ImportOrders(string filePath);
    }
}
