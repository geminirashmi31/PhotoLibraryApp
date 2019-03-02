using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoLibrary
{
    class LibraryManager
    {
        private Dictionary<string, Library> libraries;



        public void AddLibrary(string name, string coverPhotoPath)
        {

            // TODO: select foto on disk
            var newAlbum = new Library(name, coverPhotoPath);
            this.libraries.Add(name, newAlbum);
            // TODO: store library info on disk- create library folder
        }

        public void DeleteLibrary(string name)
        {

        }

    }
}
