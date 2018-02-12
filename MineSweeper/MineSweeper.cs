using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
    public class MineSweeper
    {
        Map gridSchema;
        ICollection<Coordinate> mines;
        List<string> mineMap = new List<string>();

        internal MineSweeper(Map GridSchema, ICollection<Coordinate> mineLocations)
        {
            gridSchema = GridSchema;
            mines = mineLocations;
        }
        
        internal List<string> Build()
        {
            for (int row = 1; row <= this.gridSchema.rows; row++)
            {
                string gridLine = string.Empty;

                for (int column = 1; column <= this.gridSchema.columns; column++)
                {
                    if (mines.Where(x => x.x == column && x.y == row).Any())
                    {
                        if (column < this.gridSchema.columns)
                        {
                            gridLine = gridLine + "|" + "*";
                        }
                        else if (column == this.gridSchema.columns)
                        {
                            gridLine = gridLine + "|" + "*" + "|";
                        }
                    }
                    else
                    {
                        if (column < this.gridSchema.columns)
                        {
                            gridLine = gridLine + "|" + lookupMine(row, column).ToString();
                        }
                        else if (column == this.gridSchema.columns)
                        {
                            gridLine = gridLine + "|" + lookupMine(row, column).ToString() + "|";
                        }
                    }
                }
                mineMap.Add(gridLine);
            }

            return mineMap;
        }


        int lookupMine(int row, int column)
        {
            int counter = 0;

            List<Coordinate> mineLocations = mines
                .Where(x => x.y >= row - 1 && x.y <= row + 1)
                .ToList();

            if (mineLocations.Count > 0)
            {
                foreach (var mineCoordinate in mineLocations)
                {
                    var outerCoordinates = OuterBorderCoordinates(mineCoordinate.y, mineCoordinate.x);

                    foreach (var cell in outerCoordinates)
                    {
                        if (cell.y == row)
                        {
                            if (cell.x == column)
                            {
                                counter++;
                            }
                        }
                    }
                }
            }
            return counter;
        }

        List<Coordinate> OuterBorderCoordinates(int row, int column)
        {
            return new List<Coordinate>()
            {
             new Coordinate() { x = column, y = row - 1 },
             new Coordinate() { x = column + 1, y = row - 1 }, 
             new Coordinate() { x = column + 1, y = row }, 
             new Coordinate() { x = column + 1, y = row + 1 },
             new Coordinate() { x = column, y = row + 1 },
             new Coordinate() { x = column - 1 , y = row + 1 },
             new Coordinate() { x = column - 1, y = row },
             new Coordinate() { x = column - 1, y = row - 1 }
            };
        }
    }
}

public class Map
{
    public int columns;
    public int rows;
}

public class Coordinate
{
    public int x;
    public int y;
}

