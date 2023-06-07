using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLibrary.Model
{
    public class Passwords
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Okpo { get; set; }
        public string Password { get; set; }
        public string? DateCreate { get; set; }
        public string? Comment { get; set; }
    }
}
