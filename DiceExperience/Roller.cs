using System;
using System.Linq;

namespace DiceExperience
{
    class Roller
    {
        public Dice _dice;
        public int[] _diceRecurrence;

        public Roller()
        {
            _dice = new Dice();
            _diceRecurrence = new int[6] { 1, 1, 1, 1, 1, 1 };
        }

        public int DiceRollerResult()
        {
            var diceSide = _dice.GetDiceSide(DiceRollerRandom());

            return diceSide;
        }

        private void IncrementDiceRecurrence(int i)
        {
            _diceRecurrence[i]++;
        }

        private decimal[] StatisticDiceRecurrence()
        {
            var sumDiceRecurrence = _diceRecurrence.Sum();
            var diceRecurrenceInv = new decimal[6];
            var diceStatistic = new decimal[6];

            for (int i = 0; i < 6; i++)
            {
                diceRecurrenceInv[i] = sumDiceRecurrence - _diceRecurrence[i];
            }

            var sumDiceRecurrenceInv = diceRecurrenceInv.Sum();

            for (int i = 0; i < 6; i++)
            {
                diceStatistic[i] = Math.Round(diceRecurrenceInv[i] / sumDiceRecurrenceInv, 4);

                if (i > 0)
                    diceStatistic[i] = diceStatistic[i] + diceStatistic[i - 1];
            }

            return diceStatistic;
        }

        private int DiceRollerRandom() 
        {
            Random random = new Random();

            var randomValue = (decimal)Math.Round(random.NextDouble(), 4);

            var diceStatistic = StatisticDiceRecurrence();

            foreach (var item in diceStatistic.Select((value, i) => new { i, value }))
            {
                var value = item.value;
                var index = item.i;

                if (randomValue <= value)
                {
                    IncrementDiceRecurrence(index);
                    return index;
                }
            }

            return random.Next(0, 6);
        }
    }
}
