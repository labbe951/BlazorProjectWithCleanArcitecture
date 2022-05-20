using ClosedXML.Excel;
using System;
using System.Data;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Services.Csv
{
    public class CsvDataService : ICsvDataService
    {
        public async Task<DataTable> ReadExcelToDataTable(string fileName)
        {
            var dataTable = await Task.Run(() =>
            {
                //Save the uploaded Excel file.


                DataTable dt = new DataTable();
                //Open the Excel file using ClosedXML.
                using (XLWorkbook workBook = new XLWorkbook($"App_Data/{fileName}"))
                {
                    //Read the first Sheet from Excel file.
                    IXLWorksheet workSheet = workBook.Worksheet("Samples");

                    //Create a new DataTable.

                    //Loop through the Worksheet rows.
                    bool firstRow = true;
                    foreach (IXLRow row in workSheet.Rows())
                    {

                        //Use the first row to add columns to DataTable.
                        if (firstRow)
                        {
                            foreach (IXLCell cell in row.Cells())
                            {
                                if (!string.IsNullOrEmpty(cell.Value.ToString()))
                                {
                                    dt.Columns.Add(cell.Value.ToString());
                                }
                                else
                                {
                                    break;
                                }
                            }
                            firstRow = false;
                        }
                        else
                        {
                            int i = 0;
                            DataRow toInsert = dt.NewRow();
                            foreach (IXLCell cell in row.Cells(1, dt.Columns.Count))
                            {
                                try
                                {
                                    toInsert[i] = cell.Value.ToString();
                                }
                                catch (Exception)
                                {

                                }
                                i++;
                            }
                            dt.Rows.Add(toInsert);
                        }
                    }

                }
                return dt;
            });


            return dataTable;
        }
    }
}
