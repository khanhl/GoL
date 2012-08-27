using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife.GameCoreLib;

namespace GameOfLifeTest
{
    /// <summary>
    /// Summary description for GameConstructorTests
    /// </summary>
    [TestClass]
    public class GameConstructorTests
    {
        /// <summary>
        ///A test for Game Constructor
        ///</summary>
        [TestMethod()]
        public void GameConstructorPositiveTest()
        {
            int rows = 2;
            int columns = 2;
            Game target = new Game(rows, columns);
            Assert.AreEqual(target.RowCount, 2);
            Assert.AreEqual(target.ColumnCount, 2);
        }

        /// <summary>
        ///A test for Game Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Row and Column size must be greater than or equal to zero")]
        public void GameConstructorExceptionTest1()
        {
            int rows = -1;
            int columns = 0;
            Game target = new Game(rows, columns);

        }

        /// <summary>
        ///A test for Game Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Row and Column size must be greater than zero")]
        public void GameConstructorExceptionTest2()
        {
            int rows = 0;
            int columns = -1;
            Game target = new Game(rows, columns);
        }

        /// <summary>
        ///A test for Game Constructor
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Row and Column size must be greater than zero")]
        public void GameConstructorExceptionTest3()
        {
            int rows = 0;
            int columns = 0;
            Game target = new Game(rows, columns);
        }

    }
}
