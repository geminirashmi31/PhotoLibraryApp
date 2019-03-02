using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoLibrary
{
    class Library
    {
        public string Name { get; set; }

        public List<Photo> Photos {get; set;}

        public string CoverPicPath { get; set; }

        public Library(string name, string coverPicPath)
        {
            this.Name = name;
            this.CoverPicPath = coverPicPath;
        }
    }
}
