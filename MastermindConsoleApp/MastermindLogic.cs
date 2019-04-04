using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MastermindConsoleApp
{
    public class MastermindLogic
    {
        /// <summary>
        /// Generates the 4-digit number that the user must guess.
        /// </summary>
        /// <returns>string that consists of 4 characters (each is a digit between 1-6, inclusive)</returns>
        public string GenerateMastermindNumber()
        {
            string mastermindNumber = "";
            Random randomNumber = new Random();
            for (int i = 0; i <= 3; i++)
            {
                mastermindNumber += randomNumber.Next(1, 7);
            }
            return mastermindNumber;
        }

        /// <summary>
        /// Compares user's guess to the randomly-generated 4-digit Mastermind number.
        /// </summary>
        /// <param name="magicNumber">4-digit number returned from GenerateMastermindNumber()</param>
        /// <param name="userInput">User's guess of magicNumber's value</param>
        /// <returns>string that tells user the accuracy of their guess and their number of remaining guesses</returns>
        public string GuessGeneratedNumber(string magicNumber, string userInput)
        {
            // The response returned in the console after the user submits a guess
            string feedbackForUser = "";

            // Collection of digits in magicNumber that is shortened as digits are guessed correctly
            List<char> tempNumber = magicNumber.ToList<char>();

            if (!userInput.All(char.IsDigit))
            {
                feedbackForUser = "Please enter a 4-digit number (no letters or special characters).";
            }
            else if (userInput.Length != 4)
            {
                feedbackForUser = "Please enter a 4-digit number.";
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (userInput[i] == magicNumber[i])
                    {
                        feedbackForUser += '+';
                        tempNumber.Remove(userInput[i]);
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (tempNumber.Contains(userInput[i]) && userInput[i] != magicNumber[i])
                    {
                        feedbackForUser += '-';
                        tempNumber.Remove(userInput[i]);
                    }
                }
                if (feedbackForUser == "")
                {
                    feedbackForUser = "No correct numbers.";
                }
                if (feedbackForUser == "++++")
                {
                    feedbackForUser = $"{userInput} is correct!";
                }
            }
            return feedbackForUser;
        }
    }
}
