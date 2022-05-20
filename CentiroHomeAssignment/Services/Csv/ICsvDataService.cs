using System.Data;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Services.Csv
{
    public interface ICsvDataService
    {
        Task<DataTable> ReadExcelToDataTable(string fileName);
    }
}
