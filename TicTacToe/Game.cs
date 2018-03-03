using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TicTacToe
{
    public class Board
    {
        public int x;
        public int y;
    }
    public class Coordinate
    {
        public int x;
        public int y;
    }

    internal enum Players
    {
        Player1,
        Player2,
        None
    }

    internal class Game
    {
        private int x;
        private int y;

        Dictionary<Players, Coordinate> moves = new Dictionary<Players, Coordinate>();

        public Game(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal List<string> Output = new List<string>();

        internal void Play(int x, int y)
        {
            var position = new Coordinate() { x = x, y = y };

            var lastPlayer = moves.Count > 0 ? moves.Last().Key : Players.None;

            if (lastPlayer == Players.Player1)
                Output.Add($"Player 1 has allready moved, Player 2 to go ? x :{x} y:{y}");

            if (!moves.ContainsValue(position) && !moves.ContainsKey(Players.Player1))
            {
                moves.Add(Players.Player1, position);
            }
            else
            {
                Output.Add($"Player 1 Move Invalid x:{x} y:{y}");
            }
            Output.Add($"Player 1 Move x:{x} y:{y}");

            IsWinner(this.x, this.y);
        }

        internal void ComputerMove()
        {
            foreach (var boardPosition in this.moves)
            {
                if (boardPosition.Key == Players.Player1)
                {
                    var coordinates = FindSquares(boardPosition.Value.x, boardPosition.Value.y, 1);

                    coordinates = coordinates
                        .Where(x => x.x > 0 && x.y > 0 && x.x <= this.x && x.y <= this.y).ToList();

                    var random = new Random();
                    int index = 0;

                    index = random.Next(coordinates.Count);
                    moves.Add(Players.Player2, coordinates[index]);

                    Output.Add($"Player 2 Move x:{x} y:{y}");

                    IsWinner(this.x, this.y);

                    return;
                }
            }
        }

        void IsWinner(int x, int y)
        {
            for (int i = 1; i <= x; i++)
            {
                var TopRightToBottomLeft = new List<Coordinate>();

                int width = x;
                int _row = y;
                for (int column = x; column <= x; column--)
                {
                    TopRightToBottomLeft.Add(new Coordinate() { x = column, y = _row });
                    _row--;

                    if (_row == 0)
                        break;
                }

                var TopLeftToBottomRight = new List<Coordinate>();

                width = x;
                _row = y;
                for (int column = 1; column <= x; column++)
                {
                    TopLeftToBottomRight.Add(new Coordinate() { x = column, y = _row });
                    _row++;

                    if (_row == 0)
                        break;
                }

                if (moves.Where(p => p.Key == Players.Player1 && p.Value.x == i).ToList().Count == x)
                {
                    Output.Add("Player 1 Wins");
                }
                else if (moves.Where(p => p.Key == Players.Player2 && p.Value.x == i).ToList().Count == x)
                {
                    Output.Add("Player 2 Wins");
                }
                else if (moves.Where(p => p.Key == Players.Player1 && p.Value.x == i).ToList().Count == y)
                {
                    Output.Add("Player 1 Wins");
                }
                else if (moves.Where(p => p.Key == Players.Player2 && p.Value.x == i).ToList().Count == y)
                {
                    Output.Add("Player 2 Wins");
                }
                else if (moves.Where(p => p.Key == Players.Player1)
                  .Any(a => TopRightToBottomLeft.Contains(a.Value)))
                {
                    Output.Add("Player 1 Wins");
                }
                else if (moves.Where(p => p.Key == Players.Player2)
                   .Any(a => TopRightToBottomLeft.Contains(a.Value)))
                {
                    Output.Add("Player 2 Wins");
                }
                else if (moves.Where(p => p.Key == Players.Player1)
                   .Any(a => TopLeftToBottomRight.Contains(a.Value)))
                {
                    Output.Add("Player 1 Wins");
                }
                else if (moves.Where(p => p.Key == Players.Player2)
                   .Any(a => TopLeftToBottomRight.Contains(a.Value)))
                {
                    Output.Add("Player 2 Wins");
                }
            }
        }

        List<Coordinate> GetDiagnal(int startPoint, int x, int y)
        {
            var collection = new List<Coordinate>();
            int _row = x;

            for (int column = x; column <= x; column--)
            {
                for (int row = _row; _row >= 0;)
                {
                    collection.Add(new Coordinate() { x = column, y = _row });
                    _row--;
                    break;
                }
                if (_row == 0)
                    break;
            }

            return collection;
        }

        List<Coordinate> FindSquares(int row, int column, int length)
        {
            return new List<Coordinate>()
            {
             new Coordinate() { x = column, y = row - length },
             new Coordinate() { x = column + length, y = row - length},
             new Coordinate() { x = column + length, y = row },
             new Coordinate() { x = column + length, y = row +length},
             new Coordinate() { x = column, y = row + length },
             new Coordinate() { x = column - length , y = row + 1 },
             new Coordinate() { x = column - length, y = row },
             new Coordinate() { x = column - length, y = row - length }
            };
        }
    }
}