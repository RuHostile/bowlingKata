using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microlise.Bowling.Kata
{
    public class Game
    {
        private readonly IList<Frame> _frames = new List<Frame> { new Frame() };
        private int _currentRoll;
        private Frame CurrentFrame => _frames.Last();
        public int Score()
        {
            int score = 0;
            foreach (var frame in _frames)
            {
                if (frame.IsSpare)
                {
                    score += CalculateSparebonus(frame);
                }

                if (frame.IsStrike)
                {
                    score += CalculateStrikeBonus(frame);
                }

                score += frame.TotalPinsKnockedOver;

                if (IsLastFrame(frame))
                {
                    break;
                }
            }
            return score;
        }

        private int CalculateStrikeBonus(Frame frame)
        {
            var bonus = 0;
            var nextFrame = GetNextFrame(frame);
            if (nextFrame.IsStrike)
            {
                bonus += GetNextFrame(nextFrame).FirstRoll;
            }
            bonus += nextFrame.TotalPinsKnockedOver;
            return bonus;
        }

        private int CalculateSparebonus(Frame frame)
        {
            return GetNextFrame(frame).FirstRoll;
        }

        public void RollBall(int pins)
        {
            CurrentFrame.RollBall(pins);

            if (CurrentFrame.IsComplete)
            {
                StartNewFrame();
            }
        }

        private Frame GetNextFrame(Frame frame)
        {
            return _frames[_frames.IndexOf(frame) + 1];
        }

        private void StartNewFrame()
        {
            _frames.Add(new Frame());
        }

        private bool IsLastFrame(Frame frame)
        {
            return _frames.IndexOf(frame) == 9;
        }
    }
}
