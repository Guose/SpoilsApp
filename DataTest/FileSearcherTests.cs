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
            
            //var dir = @"F:\TestFolder\";
            var customer = "Customer 1";
            var jobNumber = "123456";
            var currentFile = new FileSearcher(customer, jobNumber);

                       
            var expected = @"C:\Users\jelder\Desktop\Visual Studio JJE\TestFolder\Customer 1\123456 Blah Blah\Data\SpoilsDemo_Data.txt";

            //Act
            var actual = currentFile.RetrieveTextFilesFromCustomerFolder();

            //Assert
            Assert.AreEqual(expected, actual);

            currentFile.Dispose();
        }
    }
}