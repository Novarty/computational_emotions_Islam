namespace Islam.DAL.Migrations
{
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    using Islam.DAL.Entities;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Globalization;
	using System.IO;
	using System.Linq;
    using System.Text.RegularExpressions;
	using System.Web;

	internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        private WorkbookPart workbookPart;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
			if (context.Words.Count() == 0)
			{
				ReadStopWords(context);
			}
			if (context.Vectors.Count() == 0)
            {
                ParseXlsx(context);
            }
        }

		private void ReadStopWords(Context context)
		{
			IEnumerable<Word> words = File.ReadAllLines(HttpContext.Current.Server.MapPath(@"~\Resources\stop_words.txt"))
				.Distinct()
				.Select(w => new Word { Value = w }).ToList();
			context.Words.AddRange(words);
			context.SaveChanges();
		}

        private void ParseXlsx(Context context)
        {
			string path = HttpContext.Current.Server.MapPath(@"~\Resources\base_data.xlsx");

			using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(path, false))
            {
                workbookPart = spreadsheetDocument.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
                IEnumerable<Row> rows = sheetData.Elements<Row>();
                for (int i = 1; i < rows.Count(); i++)
                {
                    IEnumerable<Cell> cells = rows.ElementAt(i).Elements<Cell>();
                    string name = GetValue(cells.ElementAt(0));
                    if (name.Equals("0.0"))
                        break;
                    Vector vector = new Vector
                    {
                        Word = name,
                        Joy = float.Parse(GetValue(cells.ElementAt(1)), CultureInfo.InvariantCulture),
                        Trust = float.Parse(GetValue(cells.ElementAt(2)), CultureInfo.InvariantCulture),
                        Fear = float.Parse(GetValue(cells.ElementAt(3)), CultureInfo.InvariantCulture),
                        Surprise = float.Parse(GetValue(cells.ElementAt(4)), CultureInfo.InvariantCulture),
                        Sadness = float.Parse(GetValue(cells.ElementAt(5)), CultureInfo.InvariantCulture),
                        Disgust = float.Parse(GetValue(cells.ElementAt(6)), CultureInfo.InvariantCulture),
                        Anger = float.Parse(GetValue(cells.ElementAt(7)), CultureInfo.InvariantCulture),
                        Anticipation = float.Parse(GetValue(cells.ElementAt(8)), CultureInfo.InvariantCulture),
						Priority = 1d
                    };
                    context.Vectors.Add(vector);
                }
                context.SaveChanges();
            }
        }


        string GetValue(Cell cell)
        {
            string value = cell.InnerText;
            if (cell.DataType != null)
            {
                if (cell.DataType.Value == CellValues.SharedString)
                {
                    SharedStringTablePart stringTable =
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



        private string GetColumnName(string cellName)
        {
            // Create a regular expression to match the column name portion of the cell name.
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellName);

            return match.Value;
        }
    }
}
