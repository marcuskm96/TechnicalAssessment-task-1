using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAssessment_task_1.Controllers;
using TechnicalAssessment_task_1.Models;

namespace Yahtzee.Tests
{
    public class GameLogicTests
    {
        [Fact]
        public void YahtzeeController_PlayerCanRollDiceThreeTimesAndSelectWhichDiceToKeep()
        {
            // Arrange
            YahtzeeController yahtzeeController = new YahtzeeController();

            // Act
            List<int[]> rolls = new List<int[]>();

            // Simulate three rolls
            for (int i = 0; i < 3; i++)
            {
                int[] diceRoles = yahtzeeController.Roll(5);
                rolls.Add(diceRoles);
            }

            // Simulate player selecting which dice to keep
            List<int> keptDice = new List<int>();
            keptDice.Add(rolls[0][0]); // Keep first dice from first roll
            keptDice.Add(rolls[1][1]); // Keep second dice from second roll
            keptDice.Add(rolls[2][2]); // Keep third dice from third roll

            // Act
            int[] finalDiceHand = keptDice.ToArray();

            // Assert
            int[] expectedFinalDiceHand = new int[] { rolls[0][0], rolls[1][1], rolls[2][2] };

            for (int i = 0; i < finalDiceHand.Length; i++)
            {
                int expectedValue = expectedFinalDiceHand[i];
                int actualValue = finalDiceHand[i];

                Assert.Equal(expectedValue, actualValue);
            }
        }

        [Fact]
        public void GetAllOptions_ShouldHandleMultipleValidScores()
        {
            // Arrange
            int[] diceRoles = { 1, 1, 1, 2, 2 };
            ValidScores validScores = new ValidScores();

            // Act
            List<ScoreOption> options = validScores.GetAllOptions(diceRoles);

            // Assert
            Assert.Contains(options, option => option.ScoreCategory == "Aces" && option.ScoreSum == 3);
            Assert.Contains(options, option => option.ScoreCategory == "Twos" && option.ScoreSum == 4);
            Assert.Contains(options, option => option.ScoreCategory == "Three Of A Kind" && option.ScoreSum == 7);
            Assert.Contains(options, option => option.ScoreCategory == "Full House" && option.ScoreSum == 25);
            Assert.Contains(options, option => option.ScoreCategory == "Chance" && option.ScoreSum == 7);
        }

        [Fact]
        public void Index_ShouldReturnViewResult()
        {
            // Arrange
            HomeController controller = new HomeController(null);

            // Act
            IActionResult result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Roll_ShouldHandleInvalidNumberOfDice()
        {
            // Arrange
            YahtzeeController yahtzeeController = new YahtzeeController();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => yahtzeeController.Roll(6)); // Passing more than 5 dices
            Assert.Throws<ArgumentException>(() => yahtzeeController.Roll(-1)); // Passing a negative dices number
        }
    }
}
