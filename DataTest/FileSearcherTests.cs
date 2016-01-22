using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spoils.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoils.Data.Tests
{
    [TestClass()]
    public class FileSearcherTests
    {
        [TestMethod()]
        public void RetrieveTextFilesFromCustomerFolderTest()
        {
            //Arrange
            var customer = "Test Folder";
            var jobNumber = "123456";
            var currentFile = new FileSearcher(customer, jobNumber);
            string[] list = currentFile.RetrieveTextFilesFromCustomerFolder();

            var expected = 4;

            //Act
            var actual = currentFile.RetrieveTextFilesFromCustomerFolder().Count();


            //Assert
            Assert.AreEqual(expected, actual);

            currentFile.Dispose();
        }
    }
}