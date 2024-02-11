using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microlise.Bowling.Kata
{
    public class Game
    {
        private readonly int[] _knockedOverPins = new int[21];
        private int _currentRoll;
        public int Score()
        {
            int score = 0;

            for (var roll = 0; roll < _currentRoll; roll += 2)
            {
                int frameScore = _knockedOverPins[roll] + _knockedOverPins[roll + 1];
                if (frameScore == 10)
                {
                    score += _knockedOverPins[roll + 2];
                }

                score += frameScore;
            }

            return score;
        }

        public void RollBall(int pins)
        {
            _knockedOverPins[_currentRoll] = pins;
            _currentRoll++;
        }
    }
}
