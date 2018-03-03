using System.Diagnostics;
using Xunit;

namespace TicTacToe
{
    public class Tests
    {

        [Fact]
        public void Player1_Move_To_Square()
        {
            var game = new Game(3, 3);

            game.Play(1, 1);
            game.ComputerMove();

            Assert.Equal("Player 1 Move Invalid x:1 y:1", game.Output[2]);
        }
        [Fact]
        public void Player1_Move_To_Opponents_square()
        {
            var game = new Game(3, 3);

            game.Play(1, 1);
            game.Play(1, 1);
            game.ComputerMove();

            Assert.Equal("Player 1 Move Invalid x:1 y:1",game.Output[2]);
        }

        [Fact]
        public void Player_Makes_Invalid_Two_moves()
        {
            var game = new Game(3, 3);

            game.Play(1, 1);
            game.Play(1, 2);

            Assert.Equal("Player 1 Move Invalid x:1 y:1", game.Output[2]);
        }

        [Fact]
        public void Computer_First_Move()
        {
            var game = new Game(3, 3);

            game.Play(1, 1);
            game.ComputerMove();

            game.Play(1, 2);
            game.ComputerMove();

            game.Play(1, 2);
            game.ComputerMove();


        }
    }
}
