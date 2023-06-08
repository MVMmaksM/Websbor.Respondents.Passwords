using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.Respondents.Passwords.Services
{
    public class WorkFile : IWorkFile
    {
        public string ReadFile(string pathFile)
        {
            using (var streamReader = new StreamReader(pathFile))
            {
               return streamReader.ReadToEnd();
            }
        }

        public void SaveFile(string pathFile, byte[] bytesfile)
        {
            File.WriteAllBytes(pathFile, bytesfile);
        }
    }
}
