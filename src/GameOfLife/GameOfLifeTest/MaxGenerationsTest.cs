using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife.GameCoreLib;

namespace GameOfLifeTest
{
    /// <summary>
    /// Summary description for MaxGenerationsTest
    /// </summary>
    [TestClass]
    public class MaxGenerationsTest
    {
        /// <summary>
        ///A test for validating MaxGeneration value
        ///</summary>
        [TestMethod()]
        public void MaxGenerationTest()
        {
            int rows = 2;
            int columns = 2;

            Game target = new Game(rows, columns);
            target.MaxGenerations = 2;
            Assert.AreEqual(target.MaxGenerations, 2);
        }

    }
}
