using CentiroHomeAssignment.Shared.IRepositories;
using CentiroHomeAssignment.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Data.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly CentiroHomeAssignmentDbContext _centiroHomeAssignmentDbContext;
        public OrderRepository(CentiroHomeAssignmentDbContext centiroHomeAssignmentDbContext) : base(centiroHomeAssignmentDbContext)
        {
            _centiroHomeAssignmentDbContext = centiroHomeAssignmentDbContext;
        }

        /// <summary>
        /// Returns one order by order number
        /// </summary>
        /// <param name="OrderNo"></param>
        /// <returns></returns>
        public async Task<Order> GetByOrderNo(int OrderNo)
        {
            var order = await _centiroHomeAssignmentDbContext.Orders
                .FirstOrDefaultAsync(o => o.OrderNumber == OrderNo);

            return order;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _centiroHomeAssignmentDbContext.Orders
                .ToListAsync();
        }

    }
}
