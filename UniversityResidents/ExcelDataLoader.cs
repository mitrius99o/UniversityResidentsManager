using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace UniversityResidents
{
    public class ExcelDataLoader : IDataLoader
    {
        string fileName;
        public ExcelDataLoader(string fn)
        {
            fileName = fn;
        }
        public List<string> GetStringValuesFromRow(IEnumerable<Cell> cells, WorkbookPart wbp)
        {
            List<string> rowStringElements = new List<string>();
            foreach(Cell c in cells)
            {
                var cellValue = c.CellValue.Text;
                if (c.DataType != null && c.DataType == CellValues.SharedString)
                {
                    var stringId = Convert.ToInt32(c.InnerText);
                    cellValue = wbp.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(stringId).InnerText;
                    rowStringElements.Add(cellValue);
                }
                else
                {
                    rowStringElements.Add(cellValue);
                }
            }
            return rowStringElements;
        }

        public void LoadData(ref List<Person> personData)
        {
            personData = new List<Person>();
            using(SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(fileName, false))
            {
                WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
                List<string> rowCells=new List<string>();

                foreach (Row r in sheetData.Elements<Row>())
                {
                    rowCells = GetStringValuesFromRow(r.Elements<Cell>(), workbookPart);

                    switch (rowCells.First())
                    {
                        case "Студент":
                            var marks = rowCells[5]
                                .Split(" ,")
                                .Select(m => int.Parse(m))
                                .ToList();
                            var grant = int.Parse(rowCells[4]);
                            personData.Add(new Student(rowCells[2], rowCells[3], grant, marks));
                            break;
                        case "Профессор":
                            var h = int.Parse(rowCells[6]);
                            var hr = int.Parse(rowCells[7]);
                            personData.Add(new Teacher(rowCells[2], rowCells[3], hr, h));
                            break;
                        case "Сотрудник":
                            var fr = int.Parse(rowCells[8]);
                            personData.Add(new Worker(rowCells[2], rowCells[3], fr));
                            break;
                        default:
                            break;

                    }
                    rowCells.Clear();
                }
            }

        }
    }
}
