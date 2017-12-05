using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Globalization;

namespace Islam.Core
{
    class MainClass
    {
        static string textPath = @"C:\Workspace\Computational Emotions\texts\text 1.txt";
        static string excelPath = @"C:\Workspace\Computational Emotions\texts\слова и эмоции v2.xlsx";
        static WorkbookPart workbookPart;

        static void Main(string[] args)
        {
            Stemming stem = new Stemming();
            Console.WriteLine(stem.doStemming("happiness"));
            Console.WriteLine(stem.doStemming("happy"));
            Console.ReadKey();
            //ParseTextByWord(textPath);
            //GetVectorsFromExcel(excelPath);
        }

        static List<EmotionalVector> GetVectorsFromExcel(string excelPath)
        {
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(excelPath, false))
            {
                workbookPart = spreadsheetDocument.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
                var rows = sheetData.Elements<Row>();
                var vectors = new List<EmotionalVector>();
                for (int i=1; i<rows.Count(); i++)
                {
                    var cells = rows.ElementAt(i).Elements<Cell>();
                    var word = GetValue(cells.ElementAt(0));
                    if (word.Equals("0.0"))
                        break;                
                    var values = new float[8];
                    for (int j = 1; j < 9; j++)
                    {
                        var value = GetValue(cells.ElementAt(j));
                        values[j-1] = float.Parse(value, CultureInfo.InvariantCulture);
                    }
                    vectors.Add(new EmotionalVector(word, values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]));
                }
                //EmotionalVector sum = null;
                //foreach (var v in vectors)
                //{
                //    sum = sum != null ? sum + v : v;
                //}
                //Console.Write(sum.VerbalSet);
                //Console.WriteLine();
                //-
                //float valsum = 0;
                //foreach (var e in sum.EmotionalTone)
                //{
                //    Console.WriteLine(e.Emotion + " = " + e.Value);
                //    valsum += e.Value;
                //}
                //Console.Write("SUM = "+valsum);
                //Console.ReadKey();
                return vectors;
            }
        }

        static string GetValue(Cell cell)
        {
            string value = cell.InnerText;
            if (cell.DataType != null)
            {
                if (cell.DataType.Value == CellValues.SharedString)
                {
                    var stringTable =
                        workbookPart.GetPartsOfType<SharedStringTablePart>()
                        .FirstOrDefault();
                    if (stringTable != null)
                    {
                        return
                            stringTable.SharedStringTable
                            .ElementAt(int.Parse(value)).InnerText;
                    }
                }
            }
            if (value.Length < 1)
            {
                value = "0.0";
            }
            return value;
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

            EmotionalVector sum = null;
            var vectors = GetVectorsFromExcel(excelPath);
            foreach (string word in result)
            {
                var vec = vectors.Find(x => x.VerbalSet.Equals(word));
                if (vec!=null)
                {
                    Console.WriteLine(word);
                    sum = sum != null ? sum + vec : vec;
                }
            }

            Console.WriteLine();
            float valsum = 0;
            foreach (var e in sum.EmotionalTone)
            {
                Console.WriteLine(e.Emotion + " = " + e.Value);
                valsum += e.Value;
            }
            Console.Write("SUM = " + valsum);
            Console.ReadKey();
            //Console.WriteLine("Press any key to exit.");
            //System.Console.ReadKey();
        }
    }
}
