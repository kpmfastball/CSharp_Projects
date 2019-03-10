using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GuessingGame
{
    class Program
    {
        public static void Main(string[] args)
        {

            Random rnd = new Random();

            int maxLimit;
            int minLimit;
            int factor;

            getGameParameters(out maxLimit, out minLimit, out factor);

            runGame(rnd, maxLimit, minLimit, factor);
        }

        private static void runGame(Random rnd, int maxLimit, int minLimit, int factor)
        {
            int correctAnswer;
            int input;
            int numberOfGuesses = 1;

            do
            {
                do
                {
                    correctAnswer = rnd.Next(maxLimit);

                }
                while (correctAnswer < minLimit);
            }
            while (correctAnswer % factor != 0);

            try
            {

                do
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    int divideRemainder = input % factor;

                    if (input >= minLimit && input <= maxLimit)
                    {
                        if (divideRemainder == 0)
                        {
                            string guessPluralOption;

                            if (numberOfGuesses > 1)
                            {
                                guessPluralOption = "guesses";
                            }
                            else
                            {
                                guessPluralOption = "guess";
                            }

                            if (input == correctAnswer)
                            {
                                Console.WriteLine("Correct. Way to go! It took you {0} valid {1} this time.", numberOfGuesses, guessPluralOption);
                                numberOfGuesses++;
                            }
                            else if (input > correctAnswer)
                            {
                                Console.WriteLine("Too High! Try again. That is {0} valid {1} so far!", numberOfGuesses, guessPluralOption);
                                numberOfGuesses++;
                            }
                            else if (input < correctAnswer)
                            {
                                Console.WriteLine("Too low! Give it another try. That is {0} valid {1} so far!", numberOfGuesses, guessPluralOption);
                                numberOfGuesses++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Pick a number divisible {0}, please!", factor);
                        }
                    }

                    else
                    {
                        if (input > maxLimit)
                        {
                            Console.WriteLine("You cannot guess a number that is greater than {0}. Try again.", maxLimit);
                        }

                        else if (input < minLimit)
                        {
                            Console.WriteLine("You cannot guess a number less than {0}. Try again.", minLimit);
                        }
                    }
                }
                while (input < minLimit || input > maxLimit || input != correctAnswer);

                Console.ReadKey();
            }
            catch (SystemException)
            {
                Console.WriteLine("Please enter a valid number");
                runGame(rnd, maxLimit, minLimit, factor);
            }
        }

        private static void getGameParameters(out int maxLimit, out int minLimit, out int factor)
        {

            try
            {
                Console.WriteLine("Pick a number to be the minimum of the guess range:");
                minLimit = Convert.ToInt32(Console.ReadLine());

                do
                {
                    Console.WriteLine("Pick a number to be the maximum of the guess range:");
                    maxLimit = Convert.ToInt32(Console.ReadLine());

                    if (maxLimit <= minLimit)
                    {
                        Console.WriteLine("Please choose a value that is greater than {0}, which you chose as your minimum", minLimit);
                    }
                }
                while (maxLimit <= minLimit);

                bool rangeIsValid;

                do
                {
                    Console.WriteLine("What number should the answer be divisible by?:");
                    factor = Convert.ToInt32(Console.ReadLine());
                    rangeIsValid = maxLimit > factor;
                    if (rangeIsValid == false)
                    {
                        Console.WriteLine("You must choose a number that is less than the difference between your minimum and maximum selections.");
                    }
                }
                while (rangeIsValid == false);


                Console.WriteLine("Pick an number between {0} and {1} that is divisible by {2}", minLimit, maxLimit, factor);
            }
            catch (SystemException)
            {
                Console.WriteLine("Please enter a valid number");
                getGameParameters(out maxLimit, out minLimit, out factor);
            }
        }
    }
}
