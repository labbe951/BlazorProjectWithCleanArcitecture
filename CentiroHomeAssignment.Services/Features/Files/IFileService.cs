using CentiroHomeAssignment.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Services.Features.Files
{
    public interface IFileService
    {
        DataTable ConvertCSVtoDataTable(string strFilePath);
        Task<List<Order>> DataTableToListOfOrderRequestsAsync(DataTable dataTable);
    }
}
