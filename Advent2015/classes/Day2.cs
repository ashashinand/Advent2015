﻿using System;
using System.IO;
using Advent2015.interfaces;

namespace Advent2015.classes
{
    class Day2 : IAdventProblem
    {
        private int _iWrappingPaperNeeded;
        private int _iSmallestSideArea;
        private string[] _aDimensionsList;

        private bool ReadFile(string Filename)
        {
            try
            {
                _aDimensionsList = File.ReadAllLines(Filename);
            }
            catch(Exception e)
            {
                Console.WriteLine("Can't read file: {0} thrown!", e);
                return false;
            }
            return true;
        }

        public Day2()
        {
            _iWrappingPaperNeeded = 0;
            _iSmallestSideArea = -1;
        }

        public int Run()
        {
            int temp = 0;
            int[] dimensions = new int[3]; 

            Console.WriteLine("--- Day 2: I Was Told There Would Be No Math ---");
            Console.WriteLine("AKA: If I have 5 apples in one hand");
            Console.WriteLine("Please insert input filename:");
            Console.Write(">");
            string input = Console.ReadLine();
            ReadFile(input);
            foreach(string boxInput in _aDimensionsList)
            {
                //there aren't any three digit present dimensions so so it should go an order of magnitude over 10^3
                _iSmallestSideArea = 10000;

                string[] box = boxInput.Split('x');
                
                try
                {
                    //could use a for loop, far too lazy.
                    dimensions[0] = Convert.ToInt32(box[0]);
                    dimensions[1] = Convert.ToInt32(box[1]);
                    dimensions[2] = Convert.ToInt32(box[2]);
                }
                catch
                {
                    Console.WriteLine("Unknown number encountered in string '{0}'!", boxInput);
                }

                //could also do this better with an array (probably).
                temp = dimensions[0] * dimensions[1];
                if (temp < _iSmallestSideArea)
                    _iSmallestSideArea = temp;

                _iWrappingPaperNeeded += temp * 2;

                temp = dimensions[0] * dimensions[2];
                if (temp < _iSmallestSideArea)
                    _iSmallestSideArea = temp;

                _iWrappingPaperNeeded += temp * 2;


                temp = dimensions[1] * dimensions[2];
                if (temp < _iSmallestSideArea)
                    _iSmallestSideArea = temp;

                _iWrappingPaperNeeded += temp * 2;
                _iWrappingPaperNeeded += _iSmallestSideArea;
                
            }
            Console.WriteLine("Wrapping paper required: {0} ft^2", _iWrappingPaperNeeded);
            return 0;
        }
    }
}
