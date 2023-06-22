using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.Respondents.Passwords.Services
{
    public class FileDialog
    {
        public static string ShowOpenFileDialog() 
        {
            var fileDialog  = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileDialog.Filter = "*.xlsx|*.xlsx|*.txt|*.txt";

            if (fileDialog.ShowDialog() == true)
            {
                return fileDialog.FileName;
            }

            return fileDialog.FileName;
        } 
    }
}
