using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //for loop so that it will loop round 4 times
            //though it does not account for errors
            for (int loop = 0; loop < 4; loop++)
                {
                    //This is for selecting what task
                    string option;
                    Console.WriteLine("What would you like to calculate? (a/b/c/d)");
                    option = Console.ReadLine();
                    //first task
                    if (option == "a")
                    {
                        Console.WriteLine("What is number of top Films?");
                        int numberOfGrosses = int.Parse(Console.ReadLine());
                        int totalGross = 0;
                        for (int i = 0; i < numberOfGrosses; i++) //loops and stores each gross inputted
                        {
                            Console.WriteLine("Enter weekend Gross");
                            totalGross += int.Parse(Console.ReadLine()); //totals up the gross
                        }
                        Console.WriteLine("Average Gross: £" + (totalGross / numberOfGrosses)); //outputs the average
                        Console.ReadLine();
                    }
                    //second task
                    if (option == "b")
                    {
                        string country;
                        Console.WriteLine("What is the country of origin?");
                        country = Console.ReadLine();
                        Console.WriteLine("Enter number of films");
                        int weekendGross = int.Parse(Console.ReadLine());
                        int totalGross = 0;
                        for (int i = 0; i < weekendGross; i++)
                        {
                            Console.WriteLine("Enter Weekend Gross");
                            totalGross += int.Parse(Console.ReadLine());
                        }
                        Console.WriteLine("Average Gross from " + country +": £" + (totalGross / weekendGross));
                        Console.ReadLine();
                    }
                    //third task
                    if (option == "c")
                    {
                        Console.WriteLine("Enter weekend Gross for movie");
                        int weekendGross = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter ticket cost");
                        int cost = int.Parse(Console.ReadLine());
                        Console.WriteLine("The amount of viewers were: " + weekendGross / cost); //outputs the viewers
                        Console.ReadLine();

                    }
                    //extension task
                    if (option == "d")
                    {
                        string change;
                        Console.WriteLine("What is this weekend Gross?");
                        double Gross = double.Parse(Console.ReadLine());
                        Console.WriteLine("What was the percentage change?");
                        double per_change = double.Parse(Console.ReadLine());
                        Console.WriteLine("Is the change positive or negative? (p/n)");
                        change = Console.ReadLine();
                        if (change == "n")
                        {
                            per_change = per_change / 100;
                            Gross = Gross * (1 + per_change); // this calculation works out the gross by inversering the percent change
                            Console.WriteLine("Last weekend Gross was: " + Gross);
                            Console.ReadLine();
                        }
                        if (change == "p")
                        {
                            per_change = per_change / 100;
                            Gross = Gross * (1 - per_change);
                            Console.WriteLine("Last weekend Gross was:" + Gross);
                            Console.ReadLine();
                        }
                    }
                    //if one of the options is not selected
                    else
                    {
                        Console.WriteLine("That isn't one of the options.");
                        Console.WriteLine("Please select a correct option");
                        Console.ReadLine();
                    }
                }
            
        }
    }
}