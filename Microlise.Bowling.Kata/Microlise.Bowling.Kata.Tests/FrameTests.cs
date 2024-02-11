using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;

namespace Microlise.Bowling.Kata.Tests
{
    [TestFixture]
    public class FrameTests
    {
        private Frame _frame;
        [SetUp]
        public void Setup()
        {
            _frame = new Frame();
        }

        [Test]
        public void ANewGame_should_returnZero()
        {
            Assert.That(_frame.TotalPinsKnockedOver, Is.EqualTo(0));
        }

        [TestCase(1, 1, 2)]
        [TestCase(1, 6, 7)]
        [TestCase(5, 4, 9)]
        public void Frame_CanRollTwoBallsInFrame_ReturnsCorrectValue(int firstRoll, int secondRoll, int expected)
        {
            _frame.RollBall(firstRoll);
            _frame.RollBall(secondRoll);

            Assert.That(_frame.TotalPinsKnockedOver, Is.EqualTo(expected));
        }

        [TestCase(2, 9)]
        [TestCase(7, 7)]
        [TestCase(9, 9)]
        public void Frame_CanNotScoreMoreThat10InASingleFrame_ThrowsArgumentOutOfRangeException(int firstRoll, int secondRoll)
        {
            _frame.RollBall(firstRoll);

            Assert.Throws<ArgumentOutOfRangeException>(() => _frame.RollBall(secondRoll));
        }

        [TestCase(2, 8, true)]
        [TestCase(2, 2, false)]
        [TestCase(1, 8, false)]
        [TestCase(5, 5, true)]
        public void Frame_CanDetermineAFrameIsASpare_IsSpare_ReturnTrue(int firstRoll, int secondRoll, bool expected)
        {
            _frame.RollBall(firstRoll);
            _frame.RollBall(secondRoll);

            Assert.That(_frame.IsSpare, Is.EqualTo(expected));
        }

        [Test]
        public void Frame_CanDetermineAFrameIsStrike_IsStrike_RetunsTrue()
        {
            _frame.RollBall(10);

            Assert.That(_frame.IsStrike, Is.EqualTo(true));
            Assert.That(_frame.IsSpare, Is.EqualTo(false));
            Assert.That(_frame.IsComplete, Is.EqualTo(true));
        }

        [Test]
        public void Frame_IsCompleteAfterTwoRolls()
        {
            _frame.RollBall(2);
            _frame.RollBall(1);

            Assert.That(_frame.IsComplete, Is.EqualTo(true));
        }

        [Test]
        public void Frame_ACompleteFrame_CannontRollAgain()
        {
            _frame.RollBall(1);
            _frame.RollBall(2);

            Assert.Throws<ArgumentOutOfRangeException>(() => _frame.RollBall(3));
        }

        [TestCase(2, 3, 2)]
        [TestCase(7, 3, 7)]
        [TestCase(0, 10, 0)]
        public void Frame_CanDetermineNumberOfFramesInFirstRoll(int first, int second, int expected)
        {
            _frame.RollBall(first);
            _frame.RollBall(second);

            Assert.That(_frame.FirstRoll, Is.EqualTo(expected));
        }

    }
}