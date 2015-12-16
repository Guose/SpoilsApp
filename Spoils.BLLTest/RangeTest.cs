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
            var lowestNumber = new SequenceNumbers(20, 15);
            lowestNumber.CheckNumbersAreEqual();
            var expected = true;

            //Act
            var actual = lowestNumber.CheckNumbersAreEqual();

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
