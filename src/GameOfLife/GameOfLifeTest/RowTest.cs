using GameOfLife.GameCoreLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace GameOfLifeTest
{
    
    
    /// <summary>
    ///This is a test class for RowTest and is intended
    ///to contain all RowTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RowTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Row Constructor
        ///</summary>
        //[TestMethod()]
        //public void RowConstructorTest()
        //{
        //    Row target = new Row();
        //    Assert.Inconclusive("TODO: Implement code to verify target");
        //}

        /// <summary>
        ///A test for AddCell
        ///</summary>
        [TestMethod()]
        public void AddCellTest()
        {
            Row target = new Row(); // TODO: Initialize to an appropriate value
            Cell cell = new Cell(true); // TODO: Initialize to an appropriate value
            target.AddCell(cell);
            Assert.AreEqual(target.Cells[0], cell);
        }

        /// <summary>
        ///A test for InsertCell
        ///</summary>
        [TestMethod()]
        public void InsertCellTest()
        {
            Row target = new Row(); 
            Cell celltrue = new Cell(true);
            Cell cellfalse = new Cell(false);
            target.InsertCell(0, celltrue, 2);
            target.InsertCell(1, cellfalse, 2);
            Assert.AreEqual(target.Cells[0].ToString(), " X ");
            Assert.AreEqual(target.Cells[1].ToString(), " - ");
        }

        /// <summary>
        ///A test for Cells
        ///</summary>
        [TestMethod()]
        public void CellsTest()
        {
            Row target = new Row(); 
            List<Cell> expected = null; 
            List<Cell> actual;
            target.Cells = expected;
            actual = target.Cells;
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        public void ItemTest()
        {
            Row target = new Row(); 
            int y = 0; 
            Cell expected = new Cell(true); 
            Cell actual;
            target.AddCell(expected);
            actual = target.Cells[y];
            Assert.AreEqual(expected, actual);
            
        }
    }
}
