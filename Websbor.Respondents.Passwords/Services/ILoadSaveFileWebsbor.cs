using DbLibrary.Model;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.Respondents.Passwords.Services
{
    public interface ILoadSaveFileWebsbor
    {
        List<DbLibrary.Model.Passwords> LoadPasswordExcelAsync(string pathFile);
        List<DbLibrary.Model.WebsborGS> LoadWebsborGSExcelAsync(string pathFile);
        void SaveExcelAsync(byte[] bytesFile, string pathFile);
    }
}
