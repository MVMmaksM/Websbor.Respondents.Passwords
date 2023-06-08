using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Websbor.Respondents.Passwords.Services
{
    public interface IWorkFile
    {
        string ReadFile(string pathFile);
        void SaveFile(string pathFile, byte[] bytesfile);
    }
}
