using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD
{
    [TestClass]
    public class RomanNumbersCalculatorTest
    {
        [TestMethod]
        public void ForSingleRomanNumber_Calculate_ReturnsNumber()
        {
            var roman = new RomanCalculator();

            var monkey = roman.Calculate("I");
            Assert.AreEqual(1, monkey);
        }

        [TestMethod]
        public void ForMultipleSameNumbers_Calculate_ReturnsNumbersSum()
        {
            var roman = new RomanCalculator();

            var monkey = roman.Calculate("II");
            Assert.AreEqual(2, monkey);

            monkey = roman.Calculate("XX");
            Assert.AreEqual(20, monkey);

        }

        [TestMethod]
        public void ForSimpleCombination_Calculate_ReturnsDecimalRepresentation()
        {
            var roman = new RomanCalculator();

            var monkey = roman.Calculate("vI");
            Assert.AreEqual(6, monkey);

            monkey = roman.Calculate("CX");
            Assert.AreEqual(110, monkey);
        }

        [TestMethod]
        public void ForComplicatedCombination_Calculate_ReturnsDecimalRepresentation()
        {
            var roman = new RomanCalculator();

            var monkey = roman.Calculate("IV");
            Assert.AreEqual(4, monkey);

            monkey = roman.Calculate("XC");
            Assert.AreEqual(90, monkey);
        }

        [TestMethod]
        public void ForMultipleCombinations_Calculate_ReturnsDecimalRepresentation()
        {
            var roman = new RomanCalculator();

            var monkey = roman.Calculate("MCMXCVIII");
            Assert.AreEqual(1998, monkey);

            monkey = roman.Calculate("LXXXIX");
            Assert.AreEqual(89, monkey);
        }
    }

    class RomanCalculator
    {
        public int Calculate(string romanNumber)
        {
            List<int> numericList = new List<int>();

            foreach (var s in romanNumber.ToUpper())
            {
                numericList.Add(RomanNumbers.GetByChar(s));
            }

            return RecursiveRoman(numericList);
        }

        public int RecursiveRoman(List<int> romanList)
        {
            if (!romanList.Any())
            {
                return romanList.Sum();
            }

            if (AllNumbersAreTheSame(romanList))
            {
                return romanList.Sum();
            }

            if (FirstNumberIsSmallerThenSecond(romanList))
            {
                return romanList[1] - romanList[0] + RecursiveRoman(romanList.GetRange(2, romanList.Count() - 2));
            }

            var tempRoman = romanList.TakeWhile(a => a == romanList.First());

            return tempRoman.Sum() + RecursiveRoman(romanList.GetRange(tempRoman.Count(), romanList.Count() - tempRoman.Count()));

        }

        private static bool FirstNumberIsSmallerThenSecond(List<int> romanList)
        {
            return romanList[0] < romanList[1];
        }

        private static bool AllNumbersAreTheSame(List<int> numericList)
        {
            return numericList.All(a => a == numericList.First());
        }

        public static class RomanNumbers
        {
            public static readonly Dictionary<string, int> Numbers = new Dictionary<string, int>()
            {
                { "I", 1 },
                { "V", 5 },
                { "X", 10 },
                { "L", 50 },
                { "C", 100 },
                { "D", 500 },
                { "M", 1000 }
            };

            public static int GetByChar(char romanNumber)
            {
                return Numbers[romanNumber.ToString()];
            }
        }
    }
}

