﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            int index = 3;
            var customer = "Test Folder";
            var jobNumber = "123456";
            var currentFile = new FileSearcher(customer, jobNumber, index);

                       
            var expected = @"C:\Users\Justin\Desktop\Visual Studio\JJE\Test Folder\123456 Test Data Folder\Data\TEST-SpoilsDemo_Data.txt";

            //Act
            var actual = currentFile.RetrieveTextFilesFromCustomerFolder()[index];

            //Assert
            Assert.AreEqual(expected, actual);

            currentFile.Dispose();
        }
    }
}