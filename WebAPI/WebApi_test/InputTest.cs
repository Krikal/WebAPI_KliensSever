using Microsoft.VisualStudio.TestTools.UnitTesting;
using MunkafelvelvoKliens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkafelvelvoKliens.Tests
{
    [TestClass()]
    public class InputTest
    {
        [TestMethod()]
        public void ClientNameValidateTest()
        {
            // Arrange
            var clientName = "Krikal Csaladi";
            var expected = true;

            // Act

            //Assert

            Assert.AreEqual(expected, clientName);
        }
    }
}

