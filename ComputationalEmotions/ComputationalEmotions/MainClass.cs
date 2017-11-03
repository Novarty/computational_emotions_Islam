using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ComputationalEmotions
{
    class MainClass
    {
        static string textPath = @"C:\Workspace\Computational Emotions\emotions\Parser\Parser\texts\text 1.txt";
        static string excelPath = @"C:\Workspace\Computational Emotions\emotions\Parser\Parser\texts\слова и эмоции v1.xlsx";

        static void Main(string[] args)
        {
            //ParseTextByWord(textPath);
            ParseExcel(excelPath);
        }

        static void ParseExcel(string excelPath)
        {
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(excelPath, false))
            {
                WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
                foreach (Row r in sheetData.Elements<Row>())
                {
                    bool istherecell = false;
                    foreach (Cell c in r.Elements<Cell>())
                    {
                        var value = c.InnerText;
                        if (c.DataType != null)
                        {
                            istherecell = true;
                            if (c.DataType.Value == CellValues.SharedString)
                            {
                                var stringTable =
                                    workbookPart.GetPartsOfType<SharedStringTablePart>()
                                    .FirstOrDefault();
                                if (stringTable != null)
                                {
                                    value =
                                        stringTable.SharedStringTable
                                        .ElementAt(int.Parse(value)).InnerText;
                                }
                            }
                        }
                        Console.Write(value + " ");
                    }
                    if (istherecell)
                        Console.WriteLine();
                }

                Console.ReadKey();
            }
        }

        static void ParseTextByWord(string textpath)
        {
            string text = System.IO.File.ReadAllText(textpath);
            List<string> result = new List<string>();

            var words = text.Split(new char[]{' ', ',',
                    '.', '-', '"', '(', ')', ';', ':', '?', '!'});
            foreach (var word in words)
            {
                if (!result.Contains(word))
                    result.Add(word);
            }

            foreach (string word in result)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
