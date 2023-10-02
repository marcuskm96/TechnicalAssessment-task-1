using System.Collections.Generic;

namespace TechnicalAssessment_task_1.Models
{
    public class ValidScores
    {
        // This method return a list of only valid score results of each catagory, based on the final dice values
        public List<ScoreOption> GetAllOptions(int[] diceRoles)
        {
            CalculateScore calculateScore = new CalculateScore();
            List<ScoreOption> validScores = new List<ScoreOption>();

            // Upper Section
            if(calculateScore.Aces(diceRoles) > 0)
            {
                validScores.Add(new ScoreOption { ScoreCategory = "Aces", ScoreSum = calculateScore.Aces(diceRoles) });
            }
            if (calculateScore.Twos(diceRoles) > 0)
            {
                validScores.Add(new ScoreOption { ScoreCategory = "Twos", ScoreSum = calculateScore.Twos(diceRoles) });
            }
            if (calculateScore.Threes(diceRoles) > 0)
            {
                validScores.Add(new ScoreOption { ScoreCategory = "Threes", ScoreSum = calculateScore.Threes(diceRoles) });
            }
            if (calculateScore.Fours(diceRoles) > 0)
            {
                validScores.Add(new ScoreOption { ScoreCategory = "Fours", ScoreSum = calculateScore.Fours(diceRoles) });
            }
            if (calculateScore.Fives(diceRoles) > 0)
            {
                validScores.Add(new ScoreOption { ScoreCategory = "Fives", ScoreSum = calculateScore.Fives(diceRoles) });
            }
            if (calculateScore.Sixes(diceRoles) > 0)
            {
                validScores.Add(new ScoreOption { ScoreCategory = "Sixes", ScoreSum = calculateScore.Sixes(diceRoles) });
            }

            // Lower Section
            if (calculateScore.ThreeOfAKind(diceRoles) > 0)
            {
                validScores.Add(new ScoreOption { ScoreCategory = "Three Of A Kind", ScoreSum = calculateScore.ThreeOfAKind(diceRoles) });
            }
            if (calculateScore.FourOfAKind(diceRoles) > 0)
            {
                validScores.Add(new ScoreOption { ScoreCategory = "Four Of A Kind", ScoreSum = calculateScore.FourOfAKind(diceRoles) });
            }
            if (calculateScore.FullHouse(diceRoles) > 0)
            {
                validScores.Add(new ScoreOption { ScoreCategory = "Full House", ScoreSum = calculateScore.FullHouse(diceRoles) });
            }
            if (calculateScore.SmallStraight(diceRoles) > 0)
            {
                validScores.Add(new ScoreOption { ScoreCategory = "Small Straight", ScoreSum = calculateScore.SmallStraight(diceRoles) });
            }
            if (calculateScore.LargeStraight(diceRoles) > 0)
            {
                validScores.Add(new ScoreOption { ScoreCategory = "Large Straight", ScoreSum = calculateScore.LargeStraight(diceRoles) });
            }
            if (calculateScore.Yahtzee(diceRoles) > 0)
            {
                validScores.Add(new ScoreOption { ScoreCategory = "Yahtzee", ScoreSum = calculateScore.Yahtzee(diceRoles) });
            }
            if (calculateScore.Chance(diceRoles) > 0)
            {
                validScores.Add(new ScoreOption { ScoreCategory = "Chance", ScoreSum = calculateScore.Chance(diceRoles) });
            }

            return validScores;
        }
    }
}
