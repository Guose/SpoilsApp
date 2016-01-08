using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spoils.BLL;

namespace Spoils.BLLTest
{
    [TestClass()]
    public class RangeTest
    {
        [TestMethod()]
        public void NumbersAreEqual()
        {
            //Arrange
            var lowestNumber = new SequenceNumbers(5, 15);
            lowestNumber.CheckNumbersAreEqual();
            var expected = false;

            //Act
            var actual = lowestNumber.CheckNumbersAreEqual();

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
