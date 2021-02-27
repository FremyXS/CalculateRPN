using System;
using System.Collections.Generic;
using System.Text;
using RPN.Logic;

namespace RPN.Console
{
    public class DrawingTable
    {
        private static int numberOfRangeX;
        private static int numberOfRezultes;
        public DrawingTable()
        {
            numberOfRangeX = GetNumberOfSymbols(CalculateRPN.listRangeX);
            numberOfRezultes = GetNumberOfSymbols(CalculateRPN.listRezultes);

            for (int i = 1, num1 = 0, num2 = 0; i <= CalculateRPN.listRezultes.Count * 2 + 1; i++)
            {
                if (i == 1)
                    OneString('┌', '┬', '┐', '─');
                else if (i == CalculateRPN.listRezultes.Count * 2 + 1)
                    OneString('└', '┴', '┘', '─');
                else if (i % 2 == 0)
                {
                    RezultString('│', ' ', CalculateRPN.listRangeX[num1], CalculateRPN.listRezultes[num2]);

                    num1++; num2++;
                }
                else
                    OneString('├', '┼', '┤', '─');
            }
        }
        private static void OneString(char x1, char x2, char x3, char x4)
        {
            for(int j = 0; j <= numberOfRangeX + numberOfRezultes + 7; j++)
            {
                if (j == 0)
                    System.Console.Write(x1);
                else if (j == numberOfRangeX + numberOfRezultes + 7)
                    System.Console.WriteLine(x3);
                else if (j == numberOfRangeX + 3)
                    System.Console.Write(x2);
                else
                    System.Console.Write(x4);

            }
        }
        private static void RezultString(char x1, char x2, string num1, string num2)
        {
            System.Console.Write(x1);
            System.Console.Write(num1);
            System.Console.Write(new string(x2, numberOfRangeX - num1.Length + 2) + x1);
            System.Console.Write(num2);
            System.Console.WriteLine(new string(x2, numberOfRezultes - num2.Length + 3) + x1);
            
        }
        private static int GetNumberOfSymbols(List<string> numbers)
        {
            int number = 0;

            foreach(var i in numbers)
            {
                if (i.Length > number)
                    number = i.Length;
            }

            return number;
        }
    }
}
