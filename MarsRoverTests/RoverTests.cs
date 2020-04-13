using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MarsRover.Tests
{
    [TestClass]
    public class RoverTests
    {
        Mock<IInterpreter> _m = new Mock<IInterpreter>();

        [TestInitialize]
        public void Initialize()
        {
            _m.Setup(d => d.GetDirection('N')).Returns(0);
            _m.Setup(d => d.GetDirection(0)).Returns('N');
        }

        [TestMethod]
        public void MoveTest()
        {
            var r = new Rover(_m.Object, 1, 1, 'N');
            r.Move();
            _m.Verify(m => m.ChangePosition(It.IsAny<(int, int)>(), It.IsAny<int>()));
        }

        [TestMethod]
        public void TurnTest()
        {
            var r = new Rover(_m.Object, 1, 1, 'N');
            r.Turn('L');
            _m.Verify(m => m.ChangeDirection(It.IsAny<int>(), It.IsAny<char>()));
        }

        [TestMethod]
        public void ReportTest()
        {
            var r = new Rover(_m.Object, 1, 1, 'N');
            var output = r.Report();
            _m.Verify(m => m.GetDirection(It.IsAny<char>()), Times.Once);
            _m.Verify(m => m.GetDirection(It.IsAny<int>()), Times.Once);
            Assert.AreEqual(output, "1 1 N");
        }
    }
}