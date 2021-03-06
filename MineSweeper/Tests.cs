using Xunit;

namespace MineSweeper
{
    public class Tests
    {
        [Fact]
        public void Test_2_by_2_Grid()
        {
            var board = new Board()
            {
                height = 2,
                width = 2
            };

            Coordinate[] mines = { new Coordinate() { x = 1, y = 1 }, new Coordinate() { x = 2, y = 2 } };

            var mineInstance = new MineSweeper(board, mines);

            var lines = mineInstance.Play();

            Assert.Equal(lines[0], "|*|2|");
            Assert.Equal(lines[1], "|2|*|");

        }
        [Fact]
        public void Test_4_by_4_Grid()
        {
            var map = new Board()
            {
                height = 4,
                width = 4
            };

            Coordinate[] mines =
            {
                new Coordinate(){x =2,y=3},
                new Coordinate(){x =3,y=3},
                new Coordinate(){x =4,y=1},
            };

            var mineInstance = new MineSweeper(map, mines);

            var lines = mineInstance.Play();

            Assert.Equal(lines[0], "|0|0|1|*|");
            Assert.Equal(lines[1], "|1|2|3|2|");
            Assert.Equal(lines[2], "|1|*|*|1|");
            Assert.Equal(lines[3], "|1|2|2|1|");
        }
    }
}
