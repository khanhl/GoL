using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife.GameCoreLib;

namespace GameOfLifeTest
{
    /// <summary>
    /// Summary description for InitDefaultValueTest
    /// </summary>
    [TestClass]
    public class InitDefaultValueTest
    {
        /// <summary>
        ///A default test for Init
        ///</summary>
        [TestMethod()]
        public void InitialDefaultValueTest()
        {
            int rows = 2;
            int columns = 2;

            Game target = new Game(rows, columns);
            target.Init();
            Assert.AreEqual(target.InputGrid[0, 0].IsAlive, false);
            Assert.AreEqual(target.InputGrid[0, 1].IsAlive, false);
            Assert.AreEqual(target.InputGrid[1, 0].IsAlive, false);
            Assert.AreEqual(target.InputGrid[1, 1].IsAlive, false);
        }

    }
}
