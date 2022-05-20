using CentiroHomeAssignment.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Shared.IRepositories
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<Order> GetByOrderNo(int OrderNo);
        Task<List<Order>> GetAllOrders();
    }
}
