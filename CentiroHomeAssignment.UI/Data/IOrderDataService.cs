using CentiroHomeAssignment.Shared.ResponseModels;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.UI.Data
{
    public interface IOrderDataService
    {
        Task<List<OrderResponse>> GetAllOrders();
        Task ImportOrders(string filePath);
    }
}
