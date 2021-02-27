using System;
using System.IO;
using System.Collections.Generic;

namespace RPN.Logic
{
    public class Info
    {
        private static string[] information = File.ReadAllLines("filesSystem/input.txt");

        private static string function = information[0];
        public static string Function { get { return function; } } 

        private static int stepX = int.Parse(information[1]);
        public static int StepX { get { return stepX; } }

        public static List<string> GetRangeX()
        {
            List<string> rangeX = new List<string>();

            rangeX.AddRange(information[2].Split(new char[] { ' ' }));

            return rangeX;
        }

        
    }
}
