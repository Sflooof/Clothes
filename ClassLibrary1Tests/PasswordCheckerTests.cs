using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Tests
{
    [TestClass()]
    public class PasswordCheckerTests
    {
        [TestMethod()]
        public void ValidatePasswordTest()
        {
           //Arrange
           string password = "123";
            bool expected = true;

           //Act
           bool actual = PasswordChecker.ValidatePassword(password);

           //Assert
           Assert.AreEqual(expected, actual);
        }

        public void Check_4Symbols_ReturnFalse()
        {
            //Arrange
            string password = "fjv@1";

            //Act
            bool actual = PasswordChecker.ValidatePassword(password);

            //Assert
            Assert.IsFalse(actual);
        }
    }
}