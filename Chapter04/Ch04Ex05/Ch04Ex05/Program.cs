using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace Ch04Ex05
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance, interestRate, targetBalance;
            WriteLine("What is your current balance?");
            balance = ToDouble(ReadLine());
            WriteLine("What is your current annual interest rate (in %)?");
            interestRate = 1 + ToDouble(ReadLine()) / 100.0;
            WriteLine("What balance would you like to have?");

            //Part 1
            targetBalance = ToDouble(ReadLine());

            //Part 2
            //do
            //{
            //    targetBalance = ToDouble(ReadLine());
            //    if (targetBalance <= balance)
            //        WriteLine("You must enter an amount greater than " +
            //            "your current balance! \nPlease enter another value.");
            //} while (targetBalance <= balance);

            int totalYears = 0;
            while (balance < targetBalance)
            {
                balance *= interestRate;
                ++totalYears;
            }

            WriteLine($"In {totalYears} year{(totalYears == 1 ? "" : "s")} " +
                      $"you'll have a balance of {balance}.");
            if (totalYears == 0)
                WriteLine(
                   "To be honest, you really didn't need to use this calculator.");
            ReadKey();

        }
    }
}
