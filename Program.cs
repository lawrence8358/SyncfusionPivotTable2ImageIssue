using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;

namespace SyncfusionPivotTable2ImageIssue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var excelEngine = new ExcelEngine();
            var application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;
            var workbook = application.Workbooks.Create(1);

            var sheet = workbook.Worksheets[0];
            sheet.ImportData(new DataSource().Items, 1, 1, true);

            //Create Pivot cache with the given data range
            IPivotCache cache = workbook.PivotCaches.Add(sheet["A1:D6"]);

            //Create "PivotTable1" with the cache at the specified range
            IPivotTable pivotTable = sheet.PivotTables.Add("PivotTable1", sheet["F1"], cache);

            //Add Pivot table fields (Row and Column fields)
            pivotTable.Fields[0].Axis = PivotAxisTypes.Row;
            pivotTable.Fields[1].Axis = PivotAxisTypes.Row;

            //Add data field 
            pivotTable.DataFields.Add(pivotTable.Fields[2], "Sum1", PivotSubtotalTypes.Sum);
            pivotTable.DataFields.Add(pivotTable.Fields[3], "Sum2", PivotSubtotalTypes.Sum);

            //Initialize XlsIORenderer
            application.XlsIORenderer = new XlsIORenderer();

            //Converts and save as stream
            using var imageStream = new FileStream("Sample.png", FileMode.Create, FileAccess.ReadWrite);
            sheet.ConvertToImage(sheet.UsedRange, imageStream);

            using var fileStream = new FileStream("Sample.xlsx", FileMode.Create, FileAccess.Write);
            workbook.SaveAs(fileStream);

            Console.WriteLine("Done");
        }
    }
}