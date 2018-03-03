using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
    public class MineSweeper
    {
        Board board;
        Coordinate[] mines;
        List<string> mineMap = new List<string>();

        internal MineSweeper(Board boardDimensions, Coordinate[] mineLocations)
        {
            this.board = boardDimensions;
            this.mines = mineLocations;
        }
        
        internal List<string> Play()
        {
            for (int Y = 1; Y <= this.board.height; Y++)
            {
                string gridLine = string.Empty;

                for (int X = 1; X <= this.board.width; X++)
                {
                    if (mines.Where(x => x.x == X && x.y == Y).Any())
                    {
                        if (X < this.board.width)
                        {
                            gridLine = gridLine + "|" + "*";
                        }
                        else if (X == this.board.width)
                        {
                            gridLine = gridLine + "|" + "*" + "|";
                        }
                    }
                    else
                    {
                        if (X < this.board.width)
                        {
                            gridLine = gridLine + "|" + findMine(Y, X).ToString();
                        }
                        else if (X == this.board.width)
                        {
                            gridLine = gridLine + "|" + findMine(Y, X).ToString() + "|";
                        }
                    }
                }
                mineMap.Add(gridLine);
            }

            return mineMap;
        }

        int findMine(int row, int column)
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

public class Board
{
    public int width;
    public int height;
}

public class Coordinate
{
    public int x;
    public int y;
}