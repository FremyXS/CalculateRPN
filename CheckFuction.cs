using System;
using System.Collections.Generic;
using System.Text;
using RPN.Logic;

namespace RPN.Console
{
    public class CheckFuction
    {       
        public CheckFuction()
        {
            if (!CheckFuctionLogic.GetInvalidCharacter(Info.Function))
            {
                GetError();
            }
            else
            {
                GetRezult();
            }
        }
        private static void GetError()
        {
            System.Console.WriteLine(Info.Function);

            System.Console.WriteLine(new string(' ', CheckFuctionLogic.errorIndex) + "^");
        }
        private static void GetRezult()
        {
            new CalculateRPN(Logic.RPN.GetPostfix(Info.Function));

            new DrawingTable();
        }
    }
}
