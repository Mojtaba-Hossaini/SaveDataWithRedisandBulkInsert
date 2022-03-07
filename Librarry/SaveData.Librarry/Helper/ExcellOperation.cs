using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text;

namespace SaveData.Librarry.Helper;

public class ExcellOperation
{
    public static List<string> Read(string sFileName)
    {
        try
        {
            var custmerRate = new List<string>();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(sFileName, false))
            {
                WorkbookPart workbookPart = doc.WorkbookPart;
                Sheets thesheetcollection = workbookPart.Workbook.GetFirstChild<Sheets>();
                
                foreach (Sheet thesheet in thesheetcollection)
                {
                    Worksheet theWorksheet = ((WorksheetPart)workbookPart.GetPartById(thesheet.Id)).Worksheet;

                    SheetData thesheetdata = theWorksheet.GetFirstChild<SheetData>();
                    foreach (Row thecurrentrow in thesheetdata)
                    {
                        foreach (Cell thecurrentcell in thecurrentrow)
                        {
                            if (!string.IsNullOrEmpty(thecurrentcell.CellValue.InnerText))
                            {
                                if(!custmerRate.Contains(thecurrentcell.CellValue.InnerText))
                                    custmerRate.Add(thecurrentcell.CellValue.InnerText);
                            }
                        }
                    }
                }
            }
            return custmerRate;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
