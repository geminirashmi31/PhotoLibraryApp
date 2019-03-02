using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoLibraryApp;

namespace PhotoLibraryTest.UnitTests
{
    [TestClass]
    public class PhotoLibraryManagerTests
    {
        [TestMethod]
        public void CanCreateAndInitializePhotoLibraryManager()
        {
            var photoLibraryManager = new PhotoLibraryManager();
            photoLibraryManager.Initialize();

            Assert.IsTrue(File.Exists(photoLibraryManager.PhotoLibraryManagerFile)); 
        }
    }
}
