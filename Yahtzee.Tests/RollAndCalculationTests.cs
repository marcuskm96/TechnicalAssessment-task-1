using TechnicalAssessment_task_1.Controllers;
using TechnicalAssessment_task_1.Models;

namespace Yahtzee.Tests
{
    public class RollAndCalculationTests
    {
        [Fact]
        public void CalculateScore_ShouldReturnSpecifiedScoreOfRolledDices()
        {
            // Arrange
            CalculateScore calculateScore = new CalculateScore();

            int[] aces = { 1, 4, 2, 3, 1 };
            int[] twos = { 3, 1, 2, 1, 2 };
            int[] threes = { 3, 5, 2, 3, 6 };
            int[] fours = { 6, 4, 2, 2, 4 };
            int[] fives = { 5, 5, 2, 5, 6 };
            int[] sixes = { 6, 1, 2, 1, 6 };

            int[] threeOfAKind = { 4, 2, 4, 4, 3 };
            int[] fourOfAKind = { 3, 6, 3, 3, 3 };
            
            int[] fullHouse1 = { 4, 5, 4, 5, 5, };
            int[] fullHouse2 = { 4, 5, 4, 5 };
            int[] fullHouse3 = { 2, 3, 4, 5, 5, };

            int[] largeStraight1 = { 2, 3, 4, 5, 6 };
            int[] largeStraight2 = { 1, 2, 3, 4, 5 };

            int[] smallStraight1 = { 2, 4, 3, 5, 1 };
            int[] smallStraight2 = { 1, 2, 3, 4 };
            int[] smallStraight3 = { 2, 3, 4, 5 };
            int[] smallStraight4 = { 3, 4, 5, 6 };

            int[] yahtzee = { 3, 3, 3, 3, 3 };
            int[] chance = { 1, 3, 6, 5, 5 };

            // Act
            int acesSum = calculateScore.Aces(aces);
            int twosSum = calculateScore.Twos(twos);
            int threesSum = calculateScore.Threes(threes);
            int foursSum = calculateScore.Fours(fours);
            int fivesSum = calculateScore.Fives(fives);
            int sixesSum = calculateScore.Sixes(sixes);
            
            int threeOfAKindSum = calculateScore.ThreeOfAKind(threeOfAKind);
            int fourOfAKindSum = calculateScore.FourOfAKind(fourOfAKind);
            
            int fullHouseSum1 = calculateScore.FullHouse(fullHouse1);
            int fullHouseSum2 = calculateScore.FullHouse(fullHouse2);
            int fullHouseSum3 = calculateScore.FullHouse(fullHouse3);

            int largeStraightSum1 = calculateScore.LargeStraight(largeStraight1);
            int largeStraightSum2 = calculateScore.LargeStraight(largeStraight2);

            int smallStraightSum1 = calculateScore.SmallStraight(smallStraight1);
            int smallStraightSum2 = calculateScore.SmallStraight(smallStraight2);
            int smallStraightSum3 = calculateScore.SmallStraight(smallStraight3);
            int smallStraightSum4 = calculateScore.SmallStraight(smallStraight4);

            int yahtzeeSum = calculateScore.Yahtzee(yahtzee);
            int chanceSum = calculateScore.Chance(chance);

            // Assert
            Assert.Equal(2, acesSum);
            Assert.Equal(4, twosSum);
            Assert.Equal(6, threesSum);
            Assert.Equal(8, foursSum);
            Assert.Equal(15, fivesSum);
            Assert.Equal(12, sixesSum);
            
            Assert.Equal(17, threeOfAKindSum);
            Assert.Equal(18, fourOfAKindSum);

            Assert.Equal(25, fullHouseSum1);
            Assert.Equal(0, fullHouseSum2);
            Assert.Equal(0, fullHouseSum3);

            Assert.Equal(40, largeStraightSum1);
            Assert.Equal(40, largeStraightSum2);

            Assert.Equal(30, smallStraightSum1);
            Assert.Equal(30, smallStraightSum2);
            Assert.Equal(30, smallStraightSum3);
            Assert.Equal(30, smallStraightSum4);

            Assert.Equal(50, yahtzeeSum);
            Assert.Equal(20, chanceSum);
        }

        [Fact]
        public void Roll_ShouldReturnCorrectValuesOfDiceRoles()
        {
            // Arrange
            YahtzeeController yahtzeeController = new YahtzeeController();

            // Act
            int[] diceRoles = yahtzeeController.Roll(5);

            // Assert
            foreach (var dice in diceRoles)
            {
                Assert.InRange(dice, 1, 6); // Ensure each dice value is between 1 and 6
            }
        }

        [Fact]
        public void Calculate_ShouldReturnHighestValidScore()
        {
            // Arrange
            int[] diceRoles = { 6, 1, 4, 6, 6 };
            YahtzeeController yahtzeeController = new YahtzeeController();
            ValidScores validScores = new ValidScores();
            ScoreOption selectedOption = new ScoreOption();

            // Act
            List<ScoreOption> validOptions = validScores.GetAllOptions(diceRoles);
            yahtzeeController.Calculate(diceRoles);
            selectedOption = validOptions.OrderByDescending(option => option.ScoreSum).First();
            
            string excpectedScore = $"Highest possible score is Three Of A Kind: 23";
            string actualScore = $"Highest possible score is {selectedOption.ScoreCategory}: {selectedOption.ScoreSum}";
            
            // Assert
            Assert.Equal(excpectedScore, actualScore);
            Assert.Equal(23, selectedOption.ScoreSum);
        }
    }
}
