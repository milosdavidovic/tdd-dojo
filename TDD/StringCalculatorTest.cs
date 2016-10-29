using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    [TestClass]
    public class StringCalculatorTest
    {
        [TestMethod]
        public void ForEmptyString_AddMethod_ReturnZero()
        {
            var monkey = Calculator.Add("");
            Assert.AreEqual(0, monkey);
        }
        [TestMethod]
        public void ForSingleNumber_Addmethod_ReturnsSum()
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
        public void ForTwoNumbersNewLineDelimiterd_AddMethod_ReturnSum()
        {
            var monkey = Calculator.Add("2,6\n10");
            Assert.AreEqual(18, monkey);
        }
        [TestMethod]
        public void ForThreeNumbersEatherDelimited_AddMethod_ReturnsSum()
        {
            var monkey = Calculator.Add("2,6\n10");
            Assert.AreEqual(18, monkey);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ForNegatives_AddMethod_ThrowesExeption()
        {
            var monkey = Calculator.Add("-2,6\n10");
        }
        [TestMethod]
        public void ForNumbersOverOneThousand_AddMethod_IgnoresThem()
        {
            var monkey = Calculator.Add("1001,2,6\n10");
            Assert.AreEqual(18, monkey);
        }

        [TestMethod]
        public void ForSingleCharDelimiter_AddMethod_IncludesDelimiterAndReturnsSum()
        {
            var monkey = Calculator.Add("//#1001,2,6\n10#2");
            Assert.AreEqual(20, monkey);
        }
        [TestMethod]
        public void ForMultiCharDelimiter_AddMethod_ReturnSum()
        {
            var monkey = Calculator.Add("//[###]1001,2,6\n10###2###1");
            Assert.AreEqual(21, monkey);
        }
    }

    public static class Calculator
    {
        public static int Add(string v)
        {
            List<string> delimiters = new List<string>() { ",", "\n" };
            var retvalue = 0;
            if (IsEmptyString(v))
            {
                return 0;
            }
            else
            {
                if (ContainsSingleCharDelimiter(v))
                {
                    var newMultiCharDelimiter = v.Substring(3, v.IndexOf("]") - 3);
                    delimiters.Add(newMultiCharDelimiter);
                    v = v.Remove(0, newMultiCharDelimiter.Length + 4);
                }
                else if (ContainsMulticharDelimiter(v))
                {
                    delimiters.Add(v.Substring(2, 1));
                    v = v.Remove(0, 3);
                }
                retvalue = DoAdding(v, delimiters);
            }
            return retvalue;
        }

        private static int DoAdding(string v, List<string> delimiters)
        {
            var retvalue = 0;
            var numbersToSum = v.Split(delimiters.ToArray(), StringSplitOptions.None);
            foreach (var item in numbersToSum)
            {
                var number = Convert.ToInt32(item);
                if (number < 0)
                {
                    throw new ArgumentException("No negatives bitch!");
                }
                if (number > 1000)
                {
                    continue;
                }
                retvalue += number;
            }
            return retvalue;
        }

        private static bool ContainsMulticharDelimiter(string v)
        {
            return v.Contains("//");
        }

        private static bool ContainsSingleCharDelimiter(string v)
        {
            return v.Contains("//[");
        }

        private static bool IsEmptyString(string v)
        {
            return v == "";
        }
    }
}
