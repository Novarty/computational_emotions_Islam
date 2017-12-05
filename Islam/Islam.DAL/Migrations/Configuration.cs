namespace Islam.DAL.Migrations
{
	using DocumentFormat.OpenXml.Packaging;
	using DocumentFormat.OpenXml.Spreadsheet;
	using Islam.DAL.Entities;
	using Islam.Models;
	using System.Collections.Generic;
	using System.Data.Entity.Migrations;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Web;

	internal sealed class Configuration : DbMigrationsConfiguration<Context>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(Context context)
		{
			if (context.Words.Count() == 0)
			{
				ParseXlsx(context);
			}
		}


		private void ParseXlsx(Context context)
		{
			string path = HttpContext.Current.Server.MapPath(@"~\Resources\base_data.xlsx");
			WorkbookPart workbookPart;
			using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(path, true))
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
					Word word = new Word { Value = name };
					for (byte j = 1; j < 9; j++)
					{
						string value = GetValue(cells.ElementAt(j));
						float valueF = float.Parse(value, CultureInfo.InvariantCulture);
						word.Vectors.Add(new Vector { Value = valueF, Emotion = (Emotion)j });
					}
					context.Words.Add(word);
				}
				context.SaveChanges();
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
