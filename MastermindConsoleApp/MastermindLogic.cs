using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MastermindConsoleApp
{
    public class MastermindLogic
    {
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

        public string GuessGeneratedNumber(string magicNumber, string userInput)
        {
            string feedbackForUser = "";
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
                    }
                    else if (magicNumber.Contains(userInput[i]))
                    {
                        feedbackForUser += '-';
                    }
                }
                if (feedbackForUser == "")
                {
                    feedbackForUser = "No correct numbers.";
                }
            }
            return feedbackForUser;
        }
    }
}
