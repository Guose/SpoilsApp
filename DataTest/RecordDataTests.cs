using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spoils.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoils.Data.Tests
{
    [TestClass()]
    public class RecordDataTests
    {
        [TestMethod()]
        public void DataFromTextFile_Pass()
        {
            //Arrange
            var currentFile = new RecordData();
            var filePath = @"C:\Users\jelder\Desktop\Visual Studio JJE\TestFolder\Customer 1\123456 Blah Blah\Data\SpoilsDemo_Data.txt";
            var delimeter = '|';

            
            var expectedRowsCount = 300; 
            //Act
            var actual = currentFile.DataFromTextFile(filePath, delimeter);
            //Assert
            Assert.AreEqual(expectedRowsCount, actual.Rows.Count);
        }

        [TestMethod()]
        public void DataFromTextFile_Fail()
        {
            //Arrange
            var currentFile = new RecordData();
            var filePath = @"C:\Users\jelder\Desktop\Visual Studio JJE\TestFolder\Customer 1\123456 Blah Blah\Data\SpoilsDemo_Data.txt";
            var delimeter = '|';


            var expectedRowsCount = 10;
            //Act
            var actual = currentFile.DataFromTextFile(filePath, delimeter);
            //Assert
            Assert.AreNotEqual(expectedRowsCount, actual.Rows.Count);
        }
    }
}