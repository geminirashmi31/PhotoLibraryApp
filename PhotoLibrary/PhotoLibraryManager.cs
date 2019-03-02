﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoLibraryApp
{
    public class PhotoLibraryManager
    {
        private const string LIBRARY_MANAGER_FILE_NAME = "PhotoLibraryManager.txt";
        private Dictionary<string, PhotoLibrary> libraryCollection;

        public PhotoLibraryManager()
        {
            this.libraryCollection = new Dictionary<string, PhotoLibrary>();
            this.PhotoLibraryManagerFile = FileHelper.GetFilePath(LIBRARY_MANAGER_FILE_NAME).Result.Path;
        }

        public string PhotoLibraryManagerFile { get; private set; }

        public void Initialize()
        {
            this.libraryCollection = LoadPhotoLibraries().Result;
        }

        public void AddPhotoLibrary(PhotoLibrary photoLibrary)
        {
            this.libraryCollection.Add(photoLibrary.Name, photoLibrary);
            string jsonPhotoLibrary = JsonConvert.SerializeObject(this.libraryCollection.Keys.ToList());
            FileHelper.WriteTextFileAsync(LIBRARY_MANAGER_FILE_NAME, jsonPhotoLibrary);
        }

        public void RemovePhotoLibrary(string libraryName)
        {
            this.libraryCollection.Remove(libraryName);
            string jsonPhotoLibrary = JsonConvert.SerializeObject(this.libraryCollection.Keys.ToList());
            FileHelper.WriteTextFileAsync(LIBRARY_MANAGER_FILE_NAME, jsonPhotoLibrary);
        }


        private async static Task<Dictionary<string, PhotoLibrary>> LoadPhotoLibraries()
        {
            var libraryNames = await LoadPhotoLibraryNames();
            var libraries = new Dictionary<string, PhotoLibrary>();

            foreach(var lib in libraryNames)
            {
                var library = PhotoLibrary.LoadPhotoLibrary(lib).Result;

                if (library != null)
                {
                    libraries.Add(lib, library);
                }
            }

            return libraries;
            
        }

        private async static Task<List<string>> LoadPhotoLibraryNames()
        {
            string managerFileContent = await FileHelper.ReadTextFileAsync(LIBRARY_MANAGER_FILE_NAME);

            List<string> libraries = JsonConvert.DeserializeObject<List<string>>(managerFileContent);

            return libraries != null ? libraries : new List<string>();  
        }
    }
}
