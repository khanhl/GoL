using System.Collections.Generic;
using System;

namespace GameOfLife.GameCoreLib
{
    /// <summary>
    /// Cell types are unique types of cell in grid of any size
    /// Every cell type has distinct Accessible adjacent cells which can be traversed
    /// </summary>
    enum CellTypeEnum
    {
        TopLeftCorner,
        TopRightCorner,
        BottomLeftCorner,
        BottomRightCorner,
        TopSide,
        BottomSide,
        LeftSide,
        RightSide,
        Center,
        OuterTopSide,
        OuterRightSide,
        OuterBottomSide,
        OuterLeftSide,
        None
    }
    /// <summary>
    /// structure to hold x and y indices of grid cell
    /// </summary>
    struct Coordinates
    {
        public int X;
        public int Y;
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    static class AccessibleCell
    {
        // Dictionary to hold list of Accessible cells coordinates for specified cell type
        public static Dictionary<CellTypeEnum, List<Coordinates>> AccessibleCells;
        /// <summary>
        /// initialize all Accessible cells in Dictionary(Key=> CellTypeEnum, Value => List of Accessible cell co-ordinates
        /// </summary>
        public static void InitializeAccessibleCells()
        {
            CellTypeEnum innerCell;
            AccessibleCells = new Dictionary<CellTypeEnum, List<Coordinates>>();

            // Add Accessible adjacent cell coordinates for Top Left corner cell into Dictionary with TopLeftCorner CellTypeEnum as key
            innerCell = CellTypeEnum.TopLeftCorner;
            List<Coordinates> TopLeftCoOrdinateList = new List<Coordinates>();
            TopLeftCoOrdinateList.Add(new Coordinates(0, 1));
            TopLeftCoOrdinateList.Add(new Coordinates(1, 1));
            TopLeftCoOrdinateList.Add(new Coordinates(1, 0));
            AccessibleCells.Add(innerCell, TopLeftCoOrdinateList);

            // Add Accessible adjacent cell coordinates for Top right corner cell into Dictionary with TopRightCorner CellTypeEnum as key
            innerCell = CellTypeEnum.TopRightCorner;
            List<Coordinates> TopRightCoOrdinateList = new List<Coordinates>();
            TopRightCoOrdinateList.Add(new Coordinates(1, 0));
            TopRightCoOrdinateList.Add(new Coordinates(1, -1));
            TopRightCoOrdinateList.Add(new Coordinates(0, -1));
            AccessibleCells.Add(innerCell, TopRightCoOrdinateList);

            // Add Accessible adjacent cell coordinates for bottom left corner cell into Dictionary with BottomLeftCorner CellTypeEnum as key
            innerCell = CellTypeEnum.BottomLeftCorner;
            List<Coordinates> BottomLeftCoOrdinateList = new List<Coordinates>();
            BottomLeftCoOrdinateList.Add(new Coordinates(-1, 0));
            BottomLeftCoOrdinateList.Add(new Coordinates(-1, 1));
            BottomLeftCoOrdinateList.Add(new Coordinates(0, 1));
            AccessibleCells.Add(innerCell, BottomLeftCoOrdinateList);

            // Add Accessible adjacent cell coordinates for bottom right corner cell into Dictionary with BottomRightCorner CellTypeEnum as key
            innerCell = CellTypeEnum.BottomRightCorner;
            List<Coordinates> BottomRightCoOrdinateList = new List<Coordinates>();
            BottomRightCoOrdinateList.Add(new Coordinates(0, -1));
            BottomRightCoOrdinateList.Add(new Coordinates(-1, -1));
            BottomRightCoOrdinateList.Add(new Coordinates(-1, 0));
            AccessibleCells.Add(innerCell, BottomRightCoOrdinateList);

            // Add Accessible adjacent cell coordinates for top side cell into Dictionary with BottomRightCorner TopSide as key
            innerCell = CellTypeEnum.TopSide;
            List<Coordinates> TopSideCoOrdinateList = new List<Coordinates>();
            TopSideCoOrdinateList.Add(new Coordinates(0, 1));
            TopSideCoOrdinateList.Add(new Coordinates(1, 1));
            TopSideCoOrdinateList.Add(new Coordinates(1, 0));
            TopSideCoOrdinateList.Add(new Coordinates(1, -1));
            TopSideCoOrdinateList.Add(new Coordinates(0, -1));
            AccessibleCells.Add(innerCell, TopSideCoOrdinateList);

            // Add Accessible adjacent cell coordinates for bottom side cell into Dictionary with BottomRightCorner BottomSide as key
            innerCell = CellTypeEnum.BottomSide;
            List<Coordinates> BottomSideCoOrdinateList = new List<Coordinates>();
            BottomSideCoOrdinateList.Add(new Coordinates(0, -1));
            BottomSideCoOrdinateList.Add(new Coordinates(-1, -1));
            BottomSideCoOrdinateList.Add(new Coordinates(-1, 0));
            BottomSideCoOrdinateList.Add(new Coordinates(-1, 1));
            BottomSideCoOrdinateList.Add(new Coordinates(0, 1));
            AccessibleCells.Add(innerCell, BottomSideCoOrdinateList);

            // Add Accessible adjacent cell coordinates for left side cell into Dictionary with BottomRightCorner LeftSide as key
            innerCell = CellTypeEnum.LeftSide;
            List<Coordinates> LeftSideCoOrdinateList = new List<Coordinates>();
            LeftSideCoOrdinateList.Add(new Coordinates(-1, 0));
            LeftSideCoOrdinateList.Add(new Coordinates(-1, 1));
            LeftSideCoOrdinateList.Add(new Coordinates(0, 1));
            LeftSideCoOrdinateList.Add(new Coordinates(1, 1));
            LeftSideCoOrdinateList.Add(new Coordinates(1, 0));
            AccessibleCells.Add(innerCell, LeftSideCoOrdinateList);

            // Add Accessible adjacent cell coordinates for right side cell into Dictionary with BottomRightCorner RightSide as key
            innerCell = CellTypeEnum.RightSide;
            List<Coordinates> RightSideCoOrdinateList = new List<Coordinates>();
            RightSideCoOrdinateList.Add(new Coordinates(1, 0));
            RightSideCoOrdinateList.Add(new Coordinates(1, -1));
            RightSideCoOrdinateList.Add(new Coordinates(0, -1));
            RightSideCoOrdinateList.Add(new Coordinates(-1, -1));
            RightSideCoOrdinateList.Add(new Coordinates(-1, 0));
            AccessibleCells.Add(innerCell, RightSideCoOrdinateList);

            // Add Accessible adjacent cell coordinates for Center cell into Dictionary with BottomRightCorner Center as key
            innerCell = CellTypeEnum.Center;
            List<Coordinates> CenterCoOrdinateList = new List<Coordinates>();
            CenterCoOrdinateList.Add(new Coordinates(-1, 0));
            CenterCoOrdinateList.Add(new Coordinates(-1, 1));
            CenterCoOrdinateList.Add(new Coordinates(0, 1));
            CenterCoOrdinateList.Add(new Coordinates(1, 1));
            CenterCoOrdinateList.Add(new Coordinates(1, 0));
            CenterCoOrdinateList.Add(new Coordinates(1, -1));
            CenterCoOrdinateList.Add(new Coordinates(0, -1));
            CenterCoOrdinateList.Add(new Coordinates(-1, -1));
            AccessibleCells.Add(innerCell, CenterCoOrdinateList);

            // Add Accessible adjacent cell coordinates for outer top side cell into Dictionary with BottomRightCorner OuterTopSide as key
            innerCell = CellTypeEnum.OuterTopSide;
            List<Coordinates> OuterTopSideCoOrdinateList = new List<Coordinates>();
            OuterTopSideCoOrdinateList.Add(new Coordinates(1, -1));
            OuterTopSideCoOrdinateList.Add(new Coordinates(1, 0));
            OuterTopSideCoOrdinateList.Add(new Coordinates(1, 1));
            AccessibleCells.Add(innerCell, OuterTopSideCoOrdinateList);

            // Add Accessible adjacent cell co-ordinates for outer right side cell into Dictionary with BottomRightCorner OuterRightSide as key
            innerCell = CellTypeEnum.OuterRightSide;
            List<Coordinates> OuterRightSideCoOrdinateList = new List<Coordinates>();
            OuterRightSideCoOrdinateList.Add(new Coordinates(-1, -1));
            OuterRightSideCoOrdinateList.Add(new Coordinates(0, -1));
            OuterRightSideCoOrdinateList.Add(new Coordinates(1, -1));
            AccessibleCells.Add(innerCell, OuterRightSideCoOrdinateList);

            // Add Accessible adjacent cell coordinates for outer bottom side cell into Dictionary with BottomRightCorner OuterBottomSide as key
            innerCell = CellTypeEnum.OuterBottomSide;
            List<Coordinates> OuterBottomSideCoOrdinateList = new List<Coordinates>();
            OuterBottomSideCoOrdinateList.Add(new Coordinates(-1, -1));
            OuterBottomSideCoOrdinateList.Add(new Coordinates(-1, 0));
            OuterBottomSideCoOrdinateList.Add(new Coordinates(-1, 1));
            AccessibleCells.Add(innerCell, OuterBottomSideCoOrdinateList);

            // Add Accessible adjacent cell coordinates for outer left side cell into Dictionary with BottomRightCorner OuterLeftSide as key
            innerCell = CellTypeEnum.OuterLeftSide;
            List<Coordinates> OuterLeftSideCoOrdinateList = new List<Coordinates>();
            OuterLeftSideCoOrdinateList.Add(new Coordinates(-1, 1));
            OuterLeftSideCoOrdinateList.Add(new Coordinates(0, 1));
            OuterLeftSideCoOrdinateList.Add(new Coordinates(1, 1));
            AccessibleCells.Add(innerCell, OuterLeftSideCoOrdinateList);

        }

        /// <summary>
        /// Get the coordinates with respect to grid and return the Cell type enum
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="Coordinates"></param>
        /// <returns>returns CellTypeEnum</returns>
        public static CellTypeEnum GetCellType(Grid grid, Coordinates Coordinates)
        {
            if ((Coordinates.X < -1 || Coordinates.X > grid.RowCount) || (Coordinates.Y < -1 || Coordinates.Y > grid.ColumnCount))
            {
                throw new ArgumentOutOfRangeException("Invalid Index value: must be greater than or equal to minus one and less than or equal to Row count");
            }

            CellTypeEnum enumCellType = CellTypeEnum.None;
            
            if (Coordinates.X == 0 && Coordinates.Y == 0)
                enumCellType = CellTypeEnum.TopLeftCorner;
            else if (Coordinates.X == 0 && Coordinates.Y == grid.ColumnCount - 1)
                enumCellType = CellTypeEnum.TopRightCorner;
            else if (Coordinates.X == grid.RowCount - 1 && Coordinates.Y == 0)
                enumCellType = CellTypeEnum.BottomLeftCorner;
            else if (Coordinates.X == grid.RowCount - 1 && Coordinates.Y == grid.ColumnCount - 1)
                enumCellType = CellTypeEnum.BottomRightCorner;
            else if (Coordinates.X == 0 && (Coordinates.Y > 0 && Coordinates.Y < grid.ColumnCount - 1))
                enumCellType = CellTypeEnum.TopSide;
            else if (Coordinates.X == grid.RowCount - 1 && (Coordinates.Y > 0 && Coordinates.Y < grid.ColumnCount - 1))
                enumCellType = CellTypeEnum.BottomSide;
            else if ((Coordinates.X > 0 && Coordinates.X < grid.RowCount - 1) && Coordinates.Y == 0)
                enumCellType = CellTypeEnum.LeftSide;
            else if ((Coordinates.X > 0 && Coordinates.X < grid.RowCount - 1) && Coordinates.Y == grid.ColumnCount - 1)
                enumCellType = CellTypeEnum.RightSide;
            else if ((Coordinates.X > 0 && Coordinates.X < grid.RowCount - 1) && (Coordinates.Y > 0 && Coordinates.Y < grid.ColumnCount - 1))
                enumCellType = CellTypeEnum.Center;
            else if (Coordinates.X == -1 && (Coordinates.Y > 0 && Coordinates.Y < grid.ColumnCount - 1))
                enumCellType = CellTypeEnum.OuterTopSide;
            else if ((Coordinates.X > 0 && Coordinates.X < grid.RowCount - 1) && Coordinates.Y == grid.ColumnCount)
                enumCellType = CellTypeEnum.OuterRightSide;
            else if (Coordinates.X == grid.RowCount && (Coordinates.Y > 0 && Coordinates.Y < grid.ColumnCount - 1))
                enumCellType = CellTypeEnum.OuterBottomSide;
            else if ((Coordinates.X > 0 && Coordinates.X < grid.RowCount - 1) && Coordinates.Y == -1)
                enumCellType = CellTypeEnum.OuterLeftSide;

            return enumCellType;
        }

    }
}
