using System;
using System.Text;
using Advent2015.interfaces;
using System.IO;

namespace Advent2015.classes
{
    class Day1 : IAdventProblem
    {
        //variable setup
        private int _iIncrementer;
        private int _iPosition;
        private bool _bHasBeenInBasement;
        private string _sInputString;

        //I know the input string is about 8k but whatever
        private const int MAX_INPUT_SIZE = 16384;

        //haha what in the fuck fucking 254 character limit
        //Time to circumvent with IO streams
        private string ReadLine()
        {
            byte[] inputBuffer = new byte[MAX_INPUT_SIZE]; 
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            return Console.ReadLine();
        }

        //Constructor
        public Day1()
        {
            //default variable initialisation
            _iIncrementer = 0;
            _iPosition = 0;
            _sInputString = "";
        }

        //"Entry" point
        public int Run()
        {
            Console.WriteLine("--- Day 1: Not Quite Lisp ---");
            Console.WriteLine("AKA: Look dad, archaic incrementer!");
            Console.WriteLine("Please insert input string:");
            Console.Write(">");
            _sInputString = ReadLine();

            //Do we have a string?
            if (_sInputString == "")
            {
                Console.WriteLine("Yeah, thanks. Input a string next time.");
                return -1;
            }

            //Run through the inputs character at a time
            //I think this is the "best" way to do it but im not sure how fast string searching is
            foreach (char cInput in _sInputString)
            {
                // ) is down 1 floor, ( is up one floor, anything else is crash the elevator
                if (cInput == ')')
                    _iIncrementer--;
                else if (cInput == '(')
                    _iIncrementer++;
                else
                {
                    Console.WriteLine("Unknown character {0} entered!", cInput);
                    return -1;
                }

                _iPosition++;

                if (!_bHasBeenInBasement && _iIncrementer == -1)
                {
                    Console.WriteLine("Entered floor -1 at position {0}", _iPosition);
                    _bHasBeenInBasement = true;
                }
               

                
            }

            //And finally, output
            Console.WriteLine("Final floor number is: {0}", _iIncrementer);
            return 0;
        }
    }
}
