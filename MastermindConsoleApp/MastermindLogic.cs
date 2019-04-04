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
                    feedbackForUser = $"You win! {userInput} is correct!";
                }
            }
            return feedbackForUser;
        }
    }
}
