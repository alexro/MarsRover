using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace MarsRover.Tests
{
    [TestClass]
    public class BasicInterpreterTests
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
            var i = new BasicInterpreter(_m.Object);
            Assert.AreEqual(i.CorrectX(0), 0);
            Assert.AreEqual(i.CorrectX(-1), 0);
            Assert.AreEqual(i.CorrectX(11), 10);
        }

        [TestMethod]
        public void CorrectYTest()
        {
            var i = new BasicInterpreter(_m.Object);
            Assert.AreEqual(i.CorrectY(0), 0);
            Assert.AreEqual(i.CorrectY(-1), 0);
            Assert.AreEqual(i.CorrectY(11), 10);
        }

        [TestMethod]
        public void ChangeDirectionTest()
        {
            var i = new BasicInterpreter(_m.Object);

            Assert.AreEqual(i.ChangeDirection(0, 'L'), 270);
            Assert.AreEqual(i.ChangeDirection(270, 'L'), 180);
            Assert.AreEqual(i.ChangeDirection(180, 'L'), 90);
            Assert.AreEqual(i.ChangeDirection(90, 'L'), 0);

            Assert.AreEqual(i.ChangeDirection(0, 'R'), 90);
            Assert.AreEqual(i.ChangeDirection(90, 'R'), 180);
            Assert.AreEqual(i.ChangeDirection(180, 'R'), 270);
            Assert.AreEqual(i.ChangeDirection(270, 'R'), 0);
        }

        [TestMethod]
        public void ChangeDirectionErrorTest()
        {
            var i = new BasicInterpreter(_m.Object);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => i.ChangeDirection(180, 'B'));
        }

        [TestMethod]
        public void ChangePositionTest()
        {
            var i = new BasicInterpreter(_m.Object);
            Assert.AreEqual(i.ChangePosition((2, 2), 0), (2, 3));
            Assert.AreEqual(i.ChangePosition((2, 2), 90), (3, 2));
            Assert.AreEqual(i.ChangePosition((2, 2), 180), (2, 1));
            Assert.AreEqual(i.ChangePosition((2, 2), 270), (1, 2));
        }

        [TestMethod]
        public void ChangePositionErrorTest()
        {
            var i = new BasicInterpreter(_m.Object);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => i.ChangePosition((2, 2), 10));
        }

        [TestMethod]
        public void GetDirectionByIntTest()
        {
            var i = new BasicInterpreter(_m.Object);
            Assert.AreEqual(i.GetDirection(0), 'N');
            Assert.AreEqual(i.GetDirection(90), 'E');
            Assert.AreEqual(i.GetDirection(180), 'S');
            Assert.AreEqual(i.GetDirection(270), 'W');
        }

        [TestMethod]
        public void GetDirectionByCharTest()
        {
            var i = new BasicInterpreter(_m.Object);
            Assert.AreEqual(i.GetDirection('N'), 0);
            Assert.AreEqual(i.GetDirection('E'), 90);
            Assert.AreEqual(i.GetDirection('S'), 180);
            Assert.AreEqual(i.GetDirection('W'), 270);
        }
    }
}