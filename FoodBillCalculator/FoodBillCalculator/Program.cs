using System;
using System.Globalization;

namespace FoodBillCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double billCost;
            int numberOfPeople;
            double tipPercentEntry;
            bool invalidInput = true;

            while (invalidInput)
            {
                try
                {
                    GetUserInput(out billCost, out numberOfPeople, out tipPercentEntry);
                    Console.WriteLine(CalculateAmountOwed(billCost, numberOfPeople, tipPercentEntry));
                    invalidInput = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number");
                }
                catch (Exception)
                {
                    Console.WriteLine("An unknown error occured");
                }
            }
        }

        private static void GetUserInput(out double billCost, out int numberOfPeople, out double tipPercentEntry)
        {
            Console.WriteLine("How much was the bill?");

            billCost = double.Parse(Console.ReadLine());

            Console.WriteLine("How many people do you have in your party?");

            numberOfPeople = int.Parse(Console.ReadLine());

            Console.WriteLine("What percent would you like to tip?");

            tipPercentEntry = double.Parse(Console.ReadLine());

            Console.WriteLine("Each person owes:");
        }

        private static string CalculateAmountOwed(double billCost, int numberOfPeople, double tipPercentEntry)
        {
            double tipPercent = tipPercentEntry * .01f;
            double tipAmount = tipPercent * billCost;
            double amountOwed = (Math.Round((billCost + tipAmount) / numberOfPeople, 2));

            string displayResult = amountOwed.ToString("c", new CultureInfo("en-US"));

            return displayResult;
        }
    }
}
