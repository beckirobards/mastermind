using System;
using System.Collections.Generic;
using System.Text;

namespace MastermindConsoleApp
{
    public class MainMenu
    {
        MastermindLogic mastermind = new MastermindLogic();

        /// <summary>
        /// Runs the Mastermind game's main menu.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Welcome to Mastermind!");
            Console.WriteLine("In 10 guesses or less, guess the randomly-generated 4-digit number.");
            Console.WriteLine("Each digit in the magic number is between 1 and 6, inclusive.");

            // The number that the user must guess
            string magicNumber = mastermind.GenerateMastermindNumber();

            // The number of guesses that the user can take (always begins at 10)
            int remainingGuesses = 10;
            while (remainingGuesses > 0)
            {
                Console.WriteLine("Enter your guess: ");

                string userInput = Console.ReadLine();
                string response = mastermind.GuessGeneratedNumber(magicNumber, userInput);
                Console.WriteLine(response);
                remainingGuesses -= 1;

                if (userInput == magicNumber)
                {
                    Console.WriteLine("You win!");
                    break;
                }
                else if (remainingGuesses == 0)
                {
                    Console.WriteLine("Sorry, you've lost! The correct number was " + magicNumber + ".");
                    break;
                }
                else if (remainingGuesses == 1)
                {
                    Console.WriteLine($"You have 1 guess remaining.");
                }
                else
                {
                    Console.WriteLine($"You have {remainingGuesses} guesses remaining.");
                }
            }
        }
    }
}
