using NUnit.Framework;
using RPN.Logic;
using System.Collections.Generic;

namespace RPN.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        
        [TestCase("1+2", ExpectedResult = new string[] { "1", "2", "+" })]
        [TestCase("1*2+3", ExpectedResult = new string[] { "1", "2", "*", "3", "+" })]
        [TestCase("5*6+(2-9)", ExpectedResult = new string[] { "5", "6", "*", "2", "9", "-", "+" })]
        public string[] TestFunction(string expression)
        {
            return Logic.RPN.GetPostfix(expression);
        }

        [TestCase( "1+2 ", ExpectedResult = false)]
        [TestCase("1!2", ExpectedResult = false)]
        [TestCase("5*6+(2-9)", ExpectedResult = true)]
        [TestCase("(2+3))*2", ExpectedResult = false)]

        public bool TestCheckFunction(string expression)
        {
            return CheckFuctionLogic.GetInvalidCharacter(expression);
        }

        [TestCase(2, new string[]{ "1", "x", "+" }, ExpectedResult = "3")]
        [TestCase(2, new string[] { "1", "x", "*", "3", "+" }, ExpectedResult = "5")]
        [TestCase(2, new string[] { "5", "x", "*", "2", "9", "-", "+" }, ExpectedResult = "3")]

        public string TestCheckCalculate(int expression, string[] expression2)
        {
            return CalculateRPN.Calculate(expression, expression2);
        }

    }
}