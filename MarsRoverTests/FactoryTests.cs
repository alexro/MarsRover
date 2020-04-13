using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace MarsRover.Tests
{
    [TestClass]
    public class FactoryTests
    {
        Factory _f = new Factory();

        [TestMethod]
        public void CreateAreaTest()
        {
            Assert.AreEqual(_f.CreateArea(10, 11, 1, 0).GetType(), typeof(Area));
        }

        [TestMethod]
        public void CreateBasicInterpeterTest()
        {
            Assert.AreEqual(_f.CreateBasicInterpeter(null).GetType(), typeof(BasicInterpreter));
        }

        [TestMethod]
        public void CreateWrappingInterpeterTest()
        {
            Assert.AreEqual(_f.CreateWrappingInterpeter(null).GetType(), typeof(WrappingInterpreter));
        }

        [TestMethod]
        public void CreateRoverTest()
        {
            Mock<IInterpreter> _m = new Mock<IInterpreter>();
            Assert.AreEqual(_f.CreateRover(_m.Object, 0, 0, 'N').GetType(), typeof(Rover));
        }
    }
}