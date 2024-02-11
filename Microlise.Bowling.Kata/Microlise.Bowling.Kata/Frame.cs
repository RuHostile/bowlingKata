using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microlise.Bowling.Kata
{
    public class Frame
    {
        private readonly IList<int> _pinsKnockedOverEachRoll = new List<int>();
        public int TotalPinsKnockedOver => _pinsKnockedOverEachRoll.Sum();
        public int FirstRoll => _pinsKnockedOverEachRoll[0];

        public bool IsSpare => TotalPinsKnockedOver == 10 && _pinsKnockedOverEachRoll.Count == 2;
        public bool IsStrike => TotalPinsKnockedOver == 10 && _pinsKnockedOverEachRoll.Count == 1;

        public bool IsComplete => _pinsKnockedOverEachRoll.Count == 2 || IsStrike;
        public void RollBall(int pins)
        {
            if (TotalPinsKnockedOver + pins > 10 || IsComplete)
            {
                throw new ArgumentOutOfRangeException();
            }

            _pinsKnockedOverEachRoll.Add(pins);
        }
    }
}
