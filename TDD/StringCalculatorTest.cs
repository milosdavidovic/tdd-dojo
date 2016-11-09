using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TDD
{
    [TestClass]
    public class StringCalculatorTest
    {
        [TestMethod]
        public void ForEmptyString_AddMethod_ReturnsZero()
        {
            var monkey = Calculator.Add("");
            Assert.AreEqual(0, monkey);
        }
        [TestMethod]
        public void ForSingleNumber_AddMethod_ReturnsThatNumber()
        {
            var monkey = Calculator.Add("2");
            Assert.AreEqual(2, monkey);
        }
        [TestMethod]
        public void ForTwoNumbersCommaDelimited_AddMethod_ReturnsSum()
        {
            var monkey = Calculator.Add("2,3");
            Assert.AreEqual(5, monkey);
        }
        [TestMethod]
        public void ForTwoNumbersNewLineDelimited_AddMethod_ReturnsSum()
        {
            var monkey = Calculator.Add("2\n3");
            Assert.AreEqual(5, monkey);
        }
        [TestMethod]
        public void ForThreeNumbersEatherWayDelimited_AddMethod_ReturnsSum()
        {
            var monkey = Calculator.Add("2\n3,1");
            Assert.AreEqual(6, monkey);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ForNegatives_AddMethod_ThrowsExeption()
        {
            var monkey = Calculator.Add("2\n3,-1");
        }
        [TestMethod]
        public void ForNumbersOverOneThousand_AddMethod_IgnoresThem()
        {
            var monkey = Calculator.Add("2\n3,10001");
            Assert.AreEqual(5, monkey);
        }
        [TestMethod]
        public void ForSingleCharDelimitersdefined_AddMethod_AddNewDelimiterAndReturnsSum()
        {
            var monkey = Calculator.Add("//#2\n3#1");
            Assert.AreEqual(6, monkey);
        }
        [TestMethod]
        public void ForMultiCharDelimitersdefined_AddMethod_AddNewDelimiterAndReturnsSum()
        {
            var monkey = Calculator.Add("//[$#]2\n3$#1");
            Assert.AreEqual(6, monkey);
        }
    }

    public class Calculator
    {
        public static int Add(string v)
        {
            int retvalue = 0;
            List<string> delimiters = new List<string>() { ",", "\n" };
            if (!string.IsNullOrEmpty(v))
            {
                if (ContainsMulticharDelimiter(v))
                {
                    var newDelimiter = v.Substring(3, v.IndexOf("]") - 3);
                    delimiters.Add(newDelimiter);
                    v = v.Remove(0, v.IndexOf("]") + 1);
                }
                else if (ContainsSingleCharDelimiter(v))
                {
                    var newdelimiter = v.Substring(2, 1);
                    delimiters.Add(newdelimiter);
                    v = v.Remove(0, 3);
                }
                var numbers = v.Split(delimiters.ToArray(), StringSplitOptions.None);
                retvalue = DoActualAdding(numbers);
            }
            return retvalue;
        }

        private static int DoActualAdding(string[] numbers)
        {
            int retvalue = 0;
            foreach (var n in numbers)
            {
                var number = Convert.ToInt32(n);
                if (number < 0)
                {
                    throw new ArgumentException();
                }
                if (number > 1000)
                {
                    continue;
                }
                retvalue += number;
            }

            return retvalue;
        }

        private static bool ContainsSingleCharDelimiter(string v)
        {
            return v.Contains("//");
        }

        private static bool ContainsMulticharDelimiter(string v)
        {
            return v.Contains("//[");
        }
    }
}