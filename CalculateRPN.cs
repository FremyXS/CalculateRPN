using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RPN.Logic
{
    public class CalculateRPN
    {
        private static string firstNumber;
        private static string secondNumber;
        private static string rezult;

        private static List<string> rangeX = Info.GetRangeX();

        public static List<string> listRezultes { get; private set; }
        public static List<string> listRangeX { get; private set; }
        public CalculateRPN(string[] postfix)
        {
            listRangeX = new List<string>();
            listRezultes = new List<string>();

            for(int i = int.Parse(rangeX[0]); i <= int.Parse(rangeX[1]); i += Info.StepX)
            {
                listRangeX.Add(i.ToString());

                listRezultes.Add(Calculate(i, postfix));
            }
        }
        public static string Calculate(int x, string[] postfix)
        {
            Stack<string> stackCalculate = new Stack<string>();

            string symbol;

            foreach (var i in postfix)
            {
                SetNumber(out symbol, x, i);

                if (!Priority.AllOperations.Contains(symbol) && !Priority.Parenthesis.Contains(symbol))
                {
                    stackCalculate.Push(symbol);
                }
                else if (Priority.AllOperations.Contains(symbol))
                {
                    secondNumber = stackCalculate.Pop();

                    firstNumber = stackCalculate.Pop();

                    GetResult(symbol);

                    stackCalculate.Push(rezult);
                }
            }

            return stackCalculate.Pop().ToString();
        }
        private static void SetNumber(out string symbol, int x, string i )
        {
            if (i == "x")
                symbol = x.ToString();
            else
                symbol = i;
        }
        private static void GetResult(string i)
        {
            switch (i)
            {
                case "+":
                    rezult = (int.Parse(firstNumber) + int.Parse(secondNumber)).ToString();
                    break;
                case "-":
                    rezult = (int.Parse(firstNumber) - int.Parse(secondNumber)).ToString();
                    break;
                case "*":
                    rezult = (int.Parse(firstNumber) * int.Parse(secondNumber)).ToString();
                    break;
                case "/":
                    rezult = (int.Parse(firstNumber) / int.Parse(secondNumber)).ToString();
                    break;
            }            
        }
    }
}
