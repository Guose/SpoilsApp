using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spoils.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Spoils.BLL.Tests
{
    [TestClass()]
    public class SpoilsHandlerTests
    {
        [TestMethod()]
        public void RetrieveDataFromDALTest()
        {
            DataTable dt = new DataTable();
            SpoilsHandler sph = new SpoilsHandler();



            //need a first and last number to see if program works or not!!!
            var expected = 300;


            var actual = sph.RetrieveDataFromDAL(dt);
            Assert.AreEqual(expected, actual);
        }
    }
}