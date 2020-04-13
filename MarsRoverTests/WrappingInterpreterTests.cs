using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace MarsRover.Tests
{
    [TestClass]
    public class WrappingInterpreterTests
    {
        Mock<IArea> _m = new Mock<IArea>();

        [TestInitialize]
        public void Initialize()
        {
            _m.Setup(d => d.MinX).Returns(0);
            _m.Setup(d => d.MinY).Returns(0);
            _m.Setup(d => d.MaxX).Returns(10);
            _m.Setup(d => d.MaxY).Returns(10);
        }

        [TestMethod]
        public void CorrectXTest()
        {
            var i = new WrappingInterpreter(_m.Object);
            Assert.AreEqual(i.CorrectX(-1), 10);
            Assert.AreEqual(i.CorrectX(11), 0);
        }

        [TestMethod]
        public void CorrectYTest()
        {
            var i = new WrappingInterpreter(_m.Object);
            Assert.AreEqual(i.CorrectY(-1), 10);
            Assert.AreEqual(i.CorrectY(11), 0);
        }
    }
}