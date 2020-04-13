using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace MarsRover.Tests
{
    [TestClass]
    public class EmulatorTests
    {
        Mock<Factory> _mF = new Mock<Factory>();
        Mock<IArea> _mA = new Mock<IArea>();
        Mock<IInterpreter> _mI = new Mock<IInterpreter>();
        Mock<IRover> _mR = new Mock<IRover>();

        [TestInitialize]
        public void Initialize()
        {
            _mF.Setup(d => d.CreateArea(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(_mA.Object);
            _mF.Setup(d => d.CreateBasicInterpeter(_mA.Object)).Returns(_mI.Object);
            _mF.Setup(d => d.CreateWrappingInterpeter(_mA.Object)).Returns(_mI.Object);
            _mF.Setup(d => d.CreateRover(_mI.Object, It.IsAny<int>(), It.IsAny<int>(), It.IsAny<char>())).Returns(_mR.Object);
        }

        [TestMethod]
        public void ExecuteTest1()
        {
            var e = new Emulator<BasicInterpreter, Area, Rover>(_mF.Object);
            e.Execute("6 6");
            _mF.Verify(m => m.CreateArea(6, 6, 0, 0), Times.Once);
        }

        [TestMethod]
        public void ExecuteTest2()
        {
            var e = new Emulator<BasicInterpreter, Area, Rover>(_mF.Object);
            e.Execute(@"

6 6

2 2 E
MLML

");
            _mF.Verify(m => m.CreateRover(_mI.Object, 2, 2, 'E'), Times.Once);
            _mR.Verify(m => m.Move(), Times.Exactly(2));
            _mR.Verify(m => m.Turn(It.IsAny<char>()), Times.Exactly(2));
        }
    }
}