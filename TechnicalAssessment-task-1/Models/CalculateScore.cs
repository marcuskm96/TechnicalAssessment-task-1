using System;
using System.Linq;

namespace TechnicalAssessment_task_1.Models
{
    // Contains score calculation methods for all the yahtzee category rules
    public class CalculateScore
    {
        // Upper Section
        public int Aces(int[] diceRoles)
        {
            return diceRoles.Count(d => d == 1) * 1;
        }

        public int Twos(int[] diceRoles)
        {
            return diceRoles.Count(d => d == 2) * 2;
        }

        public int Threes(int[] diceRoles)
        {
            return diceRoles.Count(d => d == 3) * 3;
        }

        public int Fours(int[] diceRoles)
        {
            return diceRoles.Count(d => d == 4) * 4;
        }

        public int Fives(int[] diceRoles)
        {
            return diceRoles.Count(d => d == 5) * 5;
        }

        public int Sixes(int[] diceRoles)
        {
            return diceRoles.Count(d => d == 6) * 6;
        }

        // Lower Section
        public int ThreeOfAKind(int[] diceRoles)
        {
            int sum = 0;
            for (int i = 1; i <= 6; i++)
            {
                if (diceRoles.Count(d => d == i) >= 3)
                {
                    sum = diceRoles.Sum();
                    break;
                }
            }
            return sum;
        }

        public int FourOfAKind(int[] diceRoles)
        {
            int sum = 0;
            for (int i = 1; i <= 6; i++)
            {
                if (diceRoles.Count(d => d == i) >= 4)
                {
                    sum = diceRoles.Sum();
                    break;
                }
            }
            return sum;
        }

        public int FullHouse(int[] diceRoles)
        {
            if(diceRoles.Length != 5)
            {
                return 0;
            }

            Array.Sort(diceRoles);
            if ((diceRoles[0] == diceRoles[1] && diceRoles[3] == diceRoles[4] && diceRoles[2] == diceRoles[0]) ||
                (diceRoles[0] == diceRoles[1] && diceRoles[3] == diceRoles[4] && diceRoles[2] == diceRoles[4]))
            {
                return 25;
            }
            return 0;
        }

        public int SmallStraight(int[] diceRoles)
        {
            Array.Sort(diceRoles);
            if (diceRoles.Distinct().Count() >= 4)
            {
                for (int i = 0; i < diceRoles.Length - 1; i++)
                {
                    if (diceRoles[i + 1] - diceRoles[i] != 1)
                    {
                        return 0;
                    }
                }
                return 30;
            }
            return 0;
        }

        public int LargeStraight(int[] diceRoles)
        {
            Array.Sort(diceRoles);
            if (diceRoles.Distinct().Count() == 5)
            {
                return 40;
            }
            return 0;
        }

        public int Yahtzee(int[] diceRoles)
        {
            if (diceRoles.Length == 5 && diceRoles.All(d => d == diceRoles[0]))
            {
                return 50;
            }
            return 0;
        }

        public int Chance(int[] diceRoles)
        {
            return diceRoles.Sum();
        }
    }
}
