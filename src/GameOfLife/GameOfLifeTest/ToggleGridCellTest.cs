using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife.GameCoreLib;

namespace GameOfLifeTest
{
    /// <summary>
    /// Summary description for ToggleGridCellTest
    /// </summary>
    [TestClass]
    public class ToggleGridCellTest
    {
        /// <summary>
        ///A test for ToggleGridCell
        ///</summary>
        [TestMethod()]
        public void ToggleGridCellPositiveTest()
        {
            int rows = 2;
            int columns = 3;
            Game target = new Game(rows, columns);
            int x = 1;
            int y = 2;
            target.ToggleGridCell(x, y);
            Assert.AreEqual(target.InputGrid[1, 2].IsAlive, true);
        }

        /// <summary>
        ///A test for ToggleGridCell
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Argument out of bound")]
        public void ToggleGridCellExceptionTest1()
        {
            int rows = 1;
            int columns = 0;
            Game target = new Game(rows, columns);
            int x = 0;
            int y = 0;
            target.ToggleGridCell(x, y);
        }

        // <summary>
        ///A test for ToggleGridCell
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Argument out of bound")]
        public void ToggleGridCellExcecptinoTest2()
        {
            int rows = 0;
            int columns = 1;
            Game target = new Game(rows, columns);
            int x = 1;
            int y = 1;
            target.ToggleGridCell(x, y);
        }

        // <summary>
        ///A test for ToggleGridCell
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Argument out of bound")]
        public void ToggleGridCellExceptionTest2()
        {
            int rows = 2;
            int columns = 3;
            Game target = new Game(rows, columns);
            int x = 3;
            int y = 3;
            target.ToggleGridCell(x, y);
        }

    }
}
