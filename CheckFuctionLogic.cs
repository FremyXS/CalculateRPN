using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RPN.Logic
{
    public class CheckFuctionLogic
    {
        private static string [] trueCharacters = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "+", "-", "*", "/", "(", ")", "x"};

        public static int errorIndex { get; private set; }

        private static int numberLeftBkt = 0;
        private static int numberRightBkt = 0;

        public static bool GetInvalidCharacter(string fuction)
        {
            errorIndex = 0;

            return GetExtraCharacter(fuction);
        }
        private static bool GetExtraCharacter(string fuction)
        {
            foreach (var i in fuction)
            {
                if (!trueCharacters.Contains(i.ToString()))
                    return false;

                GetNumberOfBrackets(i);

                errorIndex++;
            }

            return GetExtraBKT(fuction);
        }
        private static bool GetExtraBKT(string fuction)
        {
            if (numberLeftBkt > numberRightBkt)
            {
                errorIndex = fuction.IndexOf('(');
                return false;
            }
            else if (numberLeftBkt < numberRightBkt)
            {
                errorIndex = fuction.IndexOf(')');
                return false;
            }

            return true;
        }
        private static void GetNumberOfBrackets(char i)
        {
            if (i == '(')
                numberLeftBkt++;
            if (i == ')')
                numberRightBkt++;
        }
    }
}
