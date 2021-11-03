using System;

namespace DiceExperience
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "1";

            var diceRoller = new Roller();

            do
            {   
                var diceResult = diceRoller.DiceRollerResult();

                Console.WriteLine("The dice roll result is: " + diceResult);

                Console.WriteLine("Type 1 to roll the dice again or type anything to quit the program");

                userInput = Console.ReadLine();

            } while (userInput == "roll");
        }
    }
}
