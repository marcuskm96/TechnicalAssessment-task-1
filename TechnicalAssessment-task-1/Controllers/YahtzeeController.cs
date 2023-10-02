using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechnicalAssessment_task_1.Models;

namespace TechnicalAssessment_task_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YahtzeeController : ControllerBase
    {
        [HttpGet]
        public string Ping()
        {
            return "Pong";
        }

        [HttpGet]
        [Route("roll/{numberOfDice}")]
        public int[] Roll(int numberOfDice)
        {
            if (numberOfDice < 0 || numberOfDice > 5)
            {
                throw new ArgumentException("Invalid number of dices. It should be between 0 and 5 dices.");
            }

            // Generates random numbers between 1 and 6 for all the rolled dices
            Random random = new Random();
            int[] rolls = new int[numberOfDice];

            for (int i = 0; i < numberOfDice; i++)
            {
                rolls[i] = random.Next(1, 7);
            }

            return rolls;
        }

        [HttpPost]
        public string Calculate(int[] diceRoles)
        {
            // Returns the highest available score of all the valid options in the list, or 0 if there is no valid score options
            ValidScores validScores = new ValidScores();
            List<ScoreOption> validOptions = validScores.GetAllOptions(diceRoles);
            ScoreOption selectedOption = validOptions.OrderByDescending(option => option.ScoreSum).FirstOrDefault();

            if (selectedOption != null)
            {
                return $"Highest possible score is {selectedOption.ScoreCategory}: {selectedOption.ScoreSum}";
            }
            else
            {
                return "0";
            }
        }
    }
}
