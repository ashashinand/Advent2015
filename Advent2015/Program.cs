using System;
using Advent2015.interfaces;
using Advent2015.classes;

namespace Advent2015
{
    class Program
    {
        //Program entry point
        static void Main(string[] args)
        {
            //variables
            int iChoice;
            string sChoice = "";
            IAdventProblem problem; 

            //basically while(true) because theres a break but incase it fails somehow, generate a false
            while(!(sChoice == "exit" || sChoice == "quit"))
            {
                iChoice = 0;
                //Was it really worth avoiding hitting the = key 20 times?
                Console.WriteLine("".PadRight(20, '='));
                Console.WriteLine("Please input number for Advent Challenge Day:");
                Console.Write(">");
                sChoice = Console.ReadLine();

                //Error handling
                try
                {
                    iChoice = Convert.ToInt32(sChoice);
                }
                catch
                {
                    //Two legitmate reasons why its not a number
                    if (sChoice == "exit" || sChoice == "quit")
                        break;

                    //otherwise yell at the user
                    Console.WriteLine("Invalid number entered!");
                }
                finally
                {
                    //If we didn't work out, leave signs that it didn't
                    if (iChoice == 0)
                        iChoice = -1;
                }

                //Good to go? wew
                if (iChoice >= 0)
                {
                    problem = null;

                    //Switch case because I dont like chaining if statements
                    switch(iChoice)
                    {
                        //HAHA
                        case 0:
                            Console.WriteLine("Jokes on you, its not zero indexed.");
                            break;
                        case 1:
                            problem = new Day1();
                            break;
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                        case 17:
                        case 18:
                        case 19:
                        case 20:
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                            Console.WriteLine("Not done yet, check back later.");
                            break;
                        default:
                            Console.WriteLine("Invalid day entered! Range is 1-25");
                            break;
                    }

                    if (problem != null)
                    {
                        problem.Run();
                    }
                }

            }
        }
    }
}
