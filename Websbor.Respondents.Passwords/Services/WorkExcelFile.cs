using DbLibrary.Model;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.Respondents.Passwords.Services
{
    public class WorkExcelFile : ILoadSaveFileWebsbor
    {
        private Dictionary<string, int?> GetNumberColumnPassword(ExcelWorksheet excelWorksheet)
        {
            var columnNumbers = new Dictionary<string, int?>();

            for (int i = 1; i <= excelWorksheet.Columns.EndColumn; i++)
            {
                var columnName = excelWorksheet.Cells[1, i]?.Value?.ToString()?.ToLower();

                switch (columnName)
                {
                    case "окпо":
                        columnNumbers.Add("Okpo", i);
                        break;
                    case "наименование":
                        columnNumbers.Add("Name", i);
                        break;
                    case "пароль":
                        columnNumbers.Add("Password", i);
                        break;
                    case "дата создания пароля":
                        columnNumbers.Add("DateCreate", i);
                        break;
                    case "примечание":
                        columnNumbers.Add("Comment", i);
                        break;
                    default:
                        columnNumbers.Add("null", null);
                        break;
                }
            }

            return columnNumbers;
        }

        private Dictionary<string, int?> GetNumberColumnWebsborGS(ExcelWorksheet excelWorksheet)
        {
            var columnNumbers = new Dictionary<string, int?>();

            for (int i = 1; i < excelWorksheet.Dimension.End.Column; i++)
            {
                var columnName = excelWorksheet.Cells[1, i]?.Value?.ToString()?.ToLower();

                switch (columnName)
                {
                    case "окпо":
                        columnNumbers.Add("Okpo", i);
                        break;
                    case "наименование":
                        columnNumbers.Add("Name", i);
                        break;
                    case "пароль":
                        columnNumbers.Add("Password", i);
                        break;
                    case "дата создания пароля":
                        columnNumbers.Add("DateCreate", i);
                        break;
                    case "примечание":
                        columnNumbers.Add("Comment", i);
                        break;
                    default:
                        columnNumbers.Add("null", null);
                        break;
                }
            }

            return columnNumbers;
        }
        public void SaveExcelAsync(byte[] bytesFile, string pathFile)
        {
            throw new NotImplementedException();
        }

        public List<DbLibrary.Model.Passwords> LoadPasswordExcelAsync(string pathFile)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                var package = new ExcelPackage(pathFile);
                var sheet = package.Workbook.Worksheets[0];

                if (sheet.Dimension is null)
                {
                    return new List<DbLibrary.Model.Passwords>();
                }

                var dataFromExcel = new List<DbLibrary.Model.Passwords>();
                var numberColumns = GetNumberColumnPassword(sheet);

                for (int i = 2; i <= sheet.Dimension.End.Row; i++)
                {
                    var row = new DbLibrary.Model.Passwords();
                    row.Name = sheet.Cells[i, (int)numberColumns["Name"]]?.Value?.ToString()?.Trim();
                    row.Okpo = sheet.Cells[i, (int)numberColumns["Okpo"]].Value.ToString().Trim();
                    row.Password = sheet.Cells[i, (int)numberColumns["Password"]].Value.ToString().Trim();
                    row.DateCreate = sheet.Cells[i, (int)numberColumns["DateCreate"]]?.Value?.ToString()?.Trim();
                    row.Comment = sheet.Cells[i, (int)numberColumns["Comment"]]?.Value?.ToString()?.Trim();

                    dataFromExcel.Add(row);
                }

                return dataFromExcel;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка чтения файла с паролями");
            }
        }

        public List<WebsborGS> LoadWebsborGSExcelAsync(string pathFile)
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var package = new ExcelPackage(pathFile);
            var sheet = package.Workbook.Worksheets[0];

            if (sheet.Dimension is null)
            {
                return new List<DbLibrary.Model.WebsborGS>();
            }

            var dataFromExcel = new List<DbLibrary.Model.WebsborGS>();        

            for (int i = 1; i <= sheet.Dimension.End.Row; i++)
            {
                var row = new DbLibrary.Model.WebsborGS();
                row.NameGS = sheet.Cells[i, 1].Value.ToString().Trim();
                row.ShortNameGS = sheet.Cells[i, 2].Value.ToString().Trim();
                row.OkpoGS = sheet.Cells[i, 3].Value.ToString().Trim();
                row.OkpoUlGS = sheet.Cells[i, 4].Value.ToString().Trim();
                row.Inn = sheet.Cells[i, 5].Value.ToString().Trim();
                row.AddressGS = sheet.Cells[i, 6].Value.ToString().Trim();
                row.TelephoneGS = sheet.Cells[i, 7].Value.ToString().Trim();
                row.DopTelephoneGs = sheet.Cells[i, 8].Value.ToString().Trim();
                row.Email = sheet.Cells[i, 9].Value.ToString().Trim();
                dataFromExcel.Add(row);
            }

            return dataFromExcel;
        }
    }
}
