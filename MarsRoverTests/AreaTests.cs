using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Tests
{
    [TestClass()]
    public class AreaTests
    {
        [TestMethod()]
        public void AreaTest()
        {
            var a = new Area(12, 14, 1, 2);
            Assert.AreEqual(a.MinX, 1);
            Assert.AreEqual(a.MinY, 2);
            Assert.AreEqual(a.MaxX, 12);
            Assert.AreEqual(a.MaxY, 14);
        }
    }
}