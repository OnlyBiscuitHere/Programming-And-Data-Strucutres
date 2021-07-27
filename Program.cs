using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _18673753_Benjamin_Fung_CMP1127M_Alt
{
    class Program
    {
        public static string choice;
        public static void Main()
        {
            Console.WriteLine("Welcome! Would you like to guess the Prime Minister or guess the date?");
            Console.WriteLine("Please enter from main, stretch or quit (uncapitalised)");
            Console.WriteLine("main = Guess the Prime Minister who served earliest");
            Console.WriteLine("stretch Guess who served on a date");
            Console.WriteLine("quit = To exit program");
            Console.WriteLine("You don't have to capitalise the words");
            while ((choice != "main") || (choice != "stretch") || (choice != "quit")) //While loop to keep the player within the program
            {
                choice = Console.ReadLine();
                if (choice == "main")
                {
                    Console.WriteLine("Guess which Prime Minister served earliest");
                    for (int i = 1; i < 6; i++) //For loop so that the player only gets 5 goes
                    {
                        //instantiation of objects
                        Game new_game = new Game();
                        Player new_player = new Player();
                        //All the functions called for the main program
                        new_game.RndPM();
                        new_game.ExHandle();
                        new_player.PlayerAns();
                        new_game.Early();
                        new_game.Check();
                        new_player.Score();
                        Console.ReadLine();
                    }
                    Console.WriteLine("Final score is: " + Player.score + " out of 5.\nPress Enter to go back to beginning."); //Closing line
                    Console.ReadLine();
                    Player.score = 0;
                }
                else if (choice == "stretch")
                {
                    //instantiation of objects
                    Game new_game = new Game();
                    Stetch New = new Stetch();
                    Player new_player = new Player();
                    //All the functions called for the stretch program
                    new_game.RndPM();
                    new_game.ExHandle();
                    New.CheckPMnDates();
                    New.GetDate();
                    new_player.PlayerAns();
                    New.Ans();
                    Console.WriteLine("Press Enter to go back to beginning."); //Closing line
                    Console.ReadLine();
                }
                else if (choice ==  "quit") //Provides an escape route for the game
                {
                    Console.WriteLine("Have a nice day!");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter main, stretch or quit.");
                    Console.WriteLine("main = Guess the Prime Minister who served earliest");
                    Console.WriteLine("stretch Guess who served on a date");
                    Console.WriteLine("quit = To exit program");
                    Console.WriteLine("You don't have to capitalise the words");
                }
            }
        }
    }
    public class Game
    {
        //Variables and instantiation
        public static string Path_PM;
        public static int PM1;
        public static int PM2;
        public static int PM3;
        public static string[] Arr_PM;
        Random rndPM = new Random();
        public static bool st = false;
        public static bool nd = false;
        public static bool rd = false;
        public static string ans;
        //Functions
        public void RndPM()
        //For calling the Prime Ministers
        {
            Path_PM = "C:/Users/user/Downloads/18673753_Benjamin Fung_CMP1127M/Prime Minister.txt"; //Finds the text file
            Arr_PM = File.ReadAllLines(Path_PM); //Read all the lines from the text file 
            //Creating random values
            PM1 = rndPM.Next(0, 75);
            PM2 = rndPM.Next(0, 75);
            PM3 = rndPM.Next(0, 75);
            if ((PM1 != PM2) && (PM2 != PM3) && (PM3 != PM1))
            {
                Console.WriteLine("Here are three Prime Ministers:");
                Console.WriteLine("\nFirst option: " + Arr_PM[PM1]);
                Console.WriteLine("Second option: " + Arr_PM[PM2]);
                Console.WriteLine("Third option: " + Arr_PM[PM3]);
            }
        }
        public void ExHandle()
        {
            //This is the function for error handling so that it checks the names of the Prime Ministers and if they throw a error then the function for calling Prime ministers is called again.
            try
            {
                if ((Arr_PM[PM1] == Arr_PM[PM2]) || (Arr_PM[PM1] == Arr_PM[PM3]) || (Arr_PM[PM2] == Arr_PM[PM3]))
                {
                    throw new Exception();
                }
            }
            catch (Exception Error)
            {
                if (Error is Exception)
                {
                    Console.WriteLine("Unfortunately in this set of Prime Ministers they are the same, here is another:");
                    RndPM();
                }
            }
            
        }
        public void Early()
        //For checking which Prime minister was the earliest
        {
            //General format is to make a comparison, confirming the comparison and then assigning the correct pointer for which is correct
            if ((PM1 < PM2) && (PM1 < PM3))
            {
                Console.WriteLine(Arr_PM[PM1] + " is the earliest Prime Minister");
                st = true;
                nd = false;
                rd = false;
            }
            if ((PM2 < PM1) && (PM2 < PM3))
            {
                Console.WriteLine(Arr_PM[PM2] + " is the earliest Prime Minister");
                nd = true;
                st = false;
                rd = false;
            }
            if ((PM3 < PM1) && (PM3 < PM2))
            {
                Console.WriteLine(Arr_PM[PM3] + " is the earliest Prime Minister");
                rd = true;
                st = false;
                nd = false;
            }
        }
        public void Check()
        //For applying the score and confirming the answer
        {
            //General format is to make comparisons and then provide an output
            if ((Player.option == "first") && (st == true))
            {
                Console.WriteLine("You are correct");
                Player.score++;
            }
            else if ((Player.option == "second") && (nd == true))
            {
                Console.WriteLine("You are correct");
                Player.score++;
            }
            else if ((Player.option == "third") && (rd == true))
            {
                Console.WriteLine("You are correct");
                Player.score++;
            }
            else
                Console.WriteLine("You are incorrect");
        }
    }
    public class Player
    {
        //Variables
        public static string option;
        public static int score;
        public static string answer;
        //Functions
        public void PlayerAns()
        //For getting the player's answer and error handling
        {
            Console.WriteLine("\nWhat is your answer?");
            while (true)
            {
                option = Console.ReadLine();
                if (option == "first" || option == "second" || option == "third")
                    break;
                else
                    Console.WriteLine("Please enter one of the following as your answer: first, second or third");
            }
        }
        public void Score()
        //For outputting the score and providing a platform for the next set of questions
        {
            Console.WriteLine("Current score is:" + score + " out of 5");
            Console.WriteLine("Press enter to continue...");
        }
    }
    public class Stetch
    {
        //Variables and instantiations
        public static string Path_Dates;
        public static string[] Arr_Dates;
        Random rndDat = new Random();
        public static int Date;
        //Functions
        public void CheckPMnDates()
        //Assigns a value for the date variable to then take on the same value as the prime minister variable
        {
            Date = rndDat.Next(1, 3);
            //General format is to make comparisons and set which is the correct choice
            if (Date == 1)
            {
                Date = Game.PM1;
                Game.st = true;
                Game.nd = false;
                Game.rd = false;
            }
            if (Date == 2)
            {
                Date = Game.PM2;
                Game.st = false;
                Game.nd = true;
                Game.rd = false;

            }
            if (Date == 3)
            {
                Date = Game.PM3;
                Game.st = false;
                Game.nd = false;
                Game.rd = true;
            }
        }
        public void GetDate()
        //Sets up the path to find the text file and output
        {
            Path_Dates = "C:/Users/user/Downloads/18673753_Benjamin Fung_CMP1127M/Dates.txt";
            Arr_Dates = File.ReadAllLines(Path_Dates);
            Console.WriteLine("\nWho Served during this time?\n" + Arr_Dates[Date]);
        }
        public void Ans()
        //For printing the answer and checking the player's answer.
        {
            Console.WriteLine("The answer is:" + Game.Arr_PM[Date]);
            Console.WriteLine("You selected: " + Player.option);
            if ((Player.option == "first") && (Game.st == true))
                Console.WriteLine("Correct, Well done!");
            else if ((Player.option == "second") && (Game.nd == true))
                Console.WriteLine("Correct, Well done!");
            else if ((Player.option == "third") && (Game.rd == true))
                Console.WriteLine("Correct, Well done!");
            else
                Console.WriteLine("Nice try");
        }
    }
}
