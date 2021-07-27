using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace _18673753_Benjamin_Fung_Assessment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //error handling
            bool var = true;
            while (var == true)
            {
                //Part a
                Console.WriteLine("Enter Hexadecimal: ");
                string hex = Console.ReadLine(); //stores the value of hexadecimal
                if ((hex.Length == 7)||(hex.Length == 6))
                {
                    //removes the # to allow for conversion
                    if (hex.StartsWith("#"))
                    {
                        hex = hex.Remove(0, 1);
                    }
                    //seperates the RGB values into their elements
                    //converts them from hexadecimal to their RGB values
                    int r = Convert.ToInt32(hex.Substring(0, 2), 16);
                    int g = Convert.ToInt32(hex.Substring(2, 2), 16);
                    int b = Convert.ToInt32(hex.Substring(4, 2), 16);
                    Console.WriteLine("\n#" + hex + ":(" + r + "," + g + "," + b + ")");
                    //Part b
                    int neg_r = 0;
                    int neg_g = 0;
                    int neg_b = 0;
                    //white's value is 255 so subtracting it from white
                    neg_r = 255 - r;
                    //conversion method for negative value to hexadecimal
                    string Neg_r = neg_r.ToString("X2");
                    neg_g = 255 - b;
                    string Neg_g = neg_g.ToString("X2");
                    neg_b = 255 - b;
                    string Neg_b = neg_b.ToString("X2");
                    Console.WriteLine("\nInverted Hexadecimal Values: #" + Neg_r + Neg_g + Neg_b);
                    Console.WriteLine("Inverted RGB Values: " + neg_r + "," + neg_g + "," + neg_b);
                    //Stretch
                    //averaging method
                    int avg = (r + g + b) / 3;
                    Console.WriteLine("\nThe grayscale value is: " + avg + " (average method)");
                    //weighted method
                    double bet_avg = ((0.3 * r) + (0.59 * g) + (0.11 * b));
                    Console.WriteLine("The greyscale value is: " + bet_avg + " (weighted method)");
                    Console.WriteLine("Enter threshold value: ");
                    double per = double.Parse(Console.ReadLine());
                    double threshold = (per / 100) * 255;
                    if (avg <= threshold)
                    {
                        Console.WriteLine("It is black");
                    }
                    if (avg > threshold)
                    {
                        Console.WriteLine("It is white");
                    }
                    var = false;
                }
                else
                {
                    Console.WriteLine("Please enter correct input for hexadecimal");
                    Console.WriteLine("For Example: #FF0000");
                }
            }
            Console.ReadLine();
        }
    }
}
