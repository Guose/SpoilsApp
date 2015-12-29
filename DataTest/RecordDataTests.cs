﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var customer = "Test Folder";
            var jobNumber = "123456";
            var currentFile = new RecordData();
            var location = new FileSearcher(customer, jobNumber, 3);
            
            var expectedRowsCount = 300; 
            //Act
            var actual = currentFile.DataFromTextFile(location.RetrieveTextFilesFromCustomerFolder(), '|');
            //Assert
            Assert.AreEqual(expectedRowsCount, actual.Rows.Count);
        }
        [TestMethod()]
        public void DataFromTextFile_FAIL()
        {
            //Arrange
            var customer = "Test Folder";
            var jobNumber = "111155";
            var currentFile = new RecordData();
            var location = new FileSearcher(customer, jobNumber, 3);

            var expectedRowsCount = 1;
            //Act
            var actual = currentFile.DataFromTextFile(location.RetrieveTextFilesFromCustomerFolder(), '|');
            //Assert
            Assert.AreEqual(expectedRowsCount, actual.Rows.Count);
        }
    }
}