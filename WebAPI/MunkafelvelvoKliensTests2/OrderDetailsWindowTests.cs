using Microsoft.VisualStudio.TestTools.UnitTesting;
using MunkafelvelvoKliens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunkafelvelvoKliens.Tests
{
    [TestClass]
    public class OrderDetailsWindowTests
    {
        [TestMethod]
        public void ClientNameValidateTest()
        {
            var orderDetailsWindow = new OrderDetailsWindow();
            Assert.AreEquals(false, orderDetailsWindow.ClientNameValidate("Krikal Csaladi*"));
            Assert.AreEquals(false, orderDetailsWindow.ClientNameValidate("Krikal Csaladi"));
        }

        [TestMethod]
        public void CarNumberPlateValidateTest()
        {
            var orderDetailsWindow = new OrderDetailsWindow();
            Assert.AreEquals(false, orderDetailsWindow.ClientNameValidate("AAA-1a2"));
            Assert.AreEquals(false, orderDetailsWindow.ClientNameValidate("AAAa1a2"));
            Assert.AreEquals(false, orderDetailsWindow.ClientNameValidate("aaa-123"));
            Assert.AreEquals(true, orderDetailsWindow.ClientNameValidate("AAA-111"));

        }
        [TestMethod]
        public void CarTypeValidateTest()
        {
            var orderDetailsWindow = new OrderDetailsWindow();
            Assert.AreEquals(false, orderDetailsWindow.CarTypeValidate("Audi*"));
            Assert.AreEquals(true, orderDetailsWindow.CarTypeValidate("Audi"));
        }
    }
}