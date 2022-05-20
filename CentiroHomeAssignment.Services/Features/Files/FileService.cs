using CentiroHomeAssignment.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Services.Features.Files
{
    public class FileService : IFileService
    {
        public DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split('|');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split('|');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }

            }


            return dt;
        }

        public async Task<List<Order>> DataTableToListOfOrderRequestsAsync(DataTable dataTable)
        {
            var listOfOrders = await Task.Run(() =>
            {
                return dataTable.AsEnumerable().Select(row => new Order
                {
                    OrderNumber = Convert.ToInt32(row["OrderNumber"]),
                    OrderLineNumber = Convert.ToInt32(row["OrderLineNumber"]),
                    ProductNumber = (row["ProductNumber"]).ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Name = (row["Name"]).ToString(),
                    Description = (row["Description"]).ToString(),
                    Price = Convert.ToDouble(row["Price"]),
                    ProductGroup = (row["ProductGroup"]).ToString(),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    CustomerName = (row["CustomerName"]).ToString(),
                    CustomerNumber = Convert.ToInt32(row["CustomerNumber"]),



                }).ToList();
            });

            return listOfOrders;
        }
    }
}
