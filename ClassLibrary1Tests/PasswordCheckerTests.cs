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
            string password = "1";
            string login = "1";

            //Act
            bool actual = PasswordChecker.ValidateUser(password, login);

            //Assert
            Assert.IsTrue(actual);
        }
        [TestMethod()]
        public void ValidatePasswordTest2()
        {
            //Arrange
            string password = "1";
            string login = " ";

            //Act
            bool actual = PasswordChecker.ValidateUser(password, login);

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void ValidatePasswordTest3()
        {
            //Arrange
            string password = "1";
            string login = "goga21";

            //Act
            bool actual = PasswordChecker.ValidateUser(password, login);

            //Assert
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void ValidateBackTest()
        {
            bool click_on = true;

            bool actual = PasswordChecker.ValidateBack(click_on);
            Assert.IsTrue(click_on);
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            string price = "3000";

            bool actual = PasswordChecker.ValidatePrice(price);
            Assert.IsTrue(actual);
        }
    }
}