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
            var customer = "Milliman";
            var jobNumber = "123456";
            var currentFile = new FileSearcher(customer, jobNumber);
            currentFile.RetrieveTextFilesFromCustomerFolder();

            var expected = @"F:\TestFolder\Milliman\123456 blah blah\Data\TEST-SpoilsDemo_Data.txt";

            //Act
            var actual = currentFile.RetrieveTextFilesFromCustomerFolder();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}