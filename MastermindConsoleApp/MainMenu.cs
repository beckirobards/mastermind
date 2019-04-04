using System;
using System.Collections.Generic;
using System.Text;

namespace MastermindConsoleApp
{
    public class MainMenu
    {
        MastermindLogic mastermind = new MastermindLogic();
        public void Run()
        {
            Console.WriteLine("Welcome to Mastermind!");
            string magicNumber = mastermind.GenerateMastermindNumber();
            int remainingGuesses = 10;
            Console.WriteLine(magicNumber);
            while (remainingGuesses > 0)
            {
                Console.WriteLine("Enter number: ");
                string userInput = Console.ReadLine();
                string response = mastermind.GuessGeneratedNumber(magicNumber, userInput);
                Console.WriteLine(response);
                remainingGuesses -= 1;
            }
        }
    }
}
