using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;

namespace Microlise.Bowling.Kata.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Game _game;
        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [Test]
        public void ANewGame_should_returnZero()
        {
            Assert.That(_game.Score, Is.EqualTo(0));
        }

        [Test]
        public void Game_AterRollingTwoBallsKnockingOverOnePin_ReturnScoreOfTwo()
        {
            _game.RollBall(1);
            _game.RollBall(1);
            Assert.That(_game.Score, Is.EqualTo(2));
        }

        [TestCase(20, 0, 0)]
        [TestCase(2, 1, 2)]
        [TestCase(20, 3, 60)]
        public void Game_RollBallKnockingOverPins_ReturnCorrectScore(int numberOfRolls, int pins, int expected)
        {
            RollMany(numberOfRolls, pins);

            Assert.That(_game.Score, Is.EqualTo(expected));
        }

        [Test]
        public void Game_AfterRollingSpare_ReturnsCorrectScore()
        {
            _game.RollBall(5);
            _game.RollBall(5);
            _game.RollBall(3);
            Assert.That(_game.Score, Is.EqualTo(16));
        }

        [Test]
        public void Game_AfterStrike_ReturnsCorrectScore()
        {
            _game.RollBall(10);
            _game.RollBall(5);
            _game.RollBall(3);

            Assert.That(_game.Score, Is.EqualTo(26));
        }

        [Test]
        public void Game_APerfectGame_ReturnsCorrectScore()
        {
            RollMany(12, 10);

            Assert.That(_game.Score(), Is.EqualTo(300));
        }

        private void RollMany(int ballsRolled, int pinsKnockedOver)
        {
            for (int i = 0; i < ballsRolled; i++)
            {
                _game.RollBall(pinsKnockedOver);
            }
        }
    }
}