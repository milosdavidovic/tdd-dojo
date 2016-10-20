using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    [TestClass]
    public class FizzBuzzPlusTest
    {
        [TestMethod]
        public void FuzzBuzzPlus_ForDividableByThree_ReturnFuzz()
        {
            var fuzzBuzzer = FuzzBuzzPlus.GetFuzzBuzzer();
            Dictionary<int, object> retvalue = fuzzBuzzer.DoFuzzBuzzPlus(100);
            Assert.AreEqual( "Fuzz", retvalue[3]);
            Assert.AreEqual("Fuzz", retvalue[33]);
            Assert.AreEqual("Fuzz", retvalue[63]);
        }

        [TestMethod]
        public void FuzzBuzzPlus_ForDevidableAndContainingThree_ReturnFuzz()
        {
            var fuzzBuzzer = FuzzBuzzPlus.GetFuzzBuzzer();
            Dictionary<int, object> retvalue = fuzzBuzzer.DoFuzzBuzzPlus(100);
            Assert.AreEqual("Fuzz", retvalue[34]);
            Assert.AreEqual("Fuzz", retvalue[23]);
            Assert.AreEqual("Fuzz", retvalue[53]);
        }

        [TestMethod]
        public void FuzzBuzzPlus_ForDevidableByFiveOrContainingFive()
        {
            var fuzzBuzzer = FuzzBuzzPlus.GetFuzzBuzzer();
            Dictionary<int, object> retvalue = fuzzBuzzer.DoFuzzBuzzPlus(100);
            Assert.AreEqual("Buzz", retvalue[5]);
            Assert.AreEqual("Buzz", retvalue[52]);
            Assert.AreEqual("Buzz", retvalue[95]);
        }
    }

    public class FuzzBuzzPlus
    {
        public static FuzzBuzzPlus GetFuzzBuzzer()
        {
            return new FuzzBuzzPlus();
        }

        public Dictionary<int, object> DoFuzzBuzzPlus(int number)
        {
            Dictionary<int, object> retvalue = new Dictionary<int, object>() { };
            for (int i = 1; i < number + 1; i++)
            {
                if (IsFuzz(i) || IsContainingDigitThree(i))
                {
                    retvalue.Add(i, "Fuzz");
                }
                else if (IsBuzz(i) || IsContainingDigitFive(i))
                {
                    retvalue.Add(i, "Buzz");
                }
                else
                {
                    retvalue.Add(i, i);
                }
            }
            return retvalue;
        }

        private bool IsBuzz(int i)
        {
            return i % 5 == 0;
        }

        private bool IsContainingDigitFive(int i)
        {
            return i.ToString().Contains("5");
        }

        private static bool IsContainingDigitThree(int i)
        {
            return i.ToString().Contains("3");
        }

        private bool IsFuzz(int number)
        {
            return number % 3 == 0;
        }
    }
}
