using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD
{
    [TestClass]
    public class FizzBuzzTest
    {
        [TestMethod]
        public void FizzBuzz_ForDefinedNuberOfIterations_ReturnsArrayOfNumberOfIterationsSize()
        {
            var fizzBuzzer = FizzBuzz.GetFizzBuzzer();
            var numberOfLinesPrinted = fizzBuzzer.DoFizzBuzz(20);
            Assert.AreEqual(numberOfLinesPrinted.Count(), 20);
        }
        [TestMethod]
        public void FizzBuzz_ForMultipleOfThree_ReturnsFizzOnRightPlaces()
        {
            var fizzBuzzer = FizzBuzz.GetFizzBuzzer();
            List<object> fuzzArray = fizzBuzzer.DoFizzBuzz(100);
            Assert.AreEqual("Fizz", (string)fuzzArray[2]);
            Assert.AreEqual("Fizz", (string)fuzzArray[8]);
            Assert.AreEqual("Fizz", (string)fuzzArray[26]);
        }
        [TestMethod]
        public void FizzBuzz_ForMultipleOfFive_ReturnsBuzzOnRightPlaces()
        {
            var fizzBuzzer = FizzBuzz.GetFizzBuzzer();
            List<object> fuzzArray = fizzBuzzer.DoFizzBuzz(100);
            Assert.AreEqual("Buzz", (string)fuzzArray[4]);
            Assert.AreEqual("Buzz", (string)fuzzArray[99]);
            Assert.AreEqual("Buzz", (string)fuzzArray[24]);
        }

        [TestMethod]
        public void FizzBuzz_ForMultipleOfFiveAndThree_ReturnsFizzBuzzOnRightPlaces()
        {
            var fizzBuzzer = FizzBuzz.GetFizzBuzzer();
            List<object> fuzzArray = fizzBuzzer.DoFizzBuzz(100);
            Assert.AreEqual("FizzBuzz", (string)fuzzArray[14]);
            Assert.AreEqual("FizzBuzz", (string)fuzzArray[29]);
            Assert.AreEqual("FizzBuzz", (string)fuzzArray[59]);
        }

    }

     class FizzBuzz
    {
        public FizzBuzz()
        {

        }

        public static FizzBuzz GetFizzBuzzer()
        {
            return new FizzBuzz();
        }

        public List<object> DoFizzBuzz(int nuberOfIterations)
        {
            List<object> retList = new List<object>();
            for (int i = 1; i < nuberOfIterations + 1; i++)
            {
                if (IsFizzBuzz(i))
                {
                    retList.Add("FizzBuzz");
                }
                else if (IsFizz(i))
                {
                    retList.Add("Fizz");
                }
                else if (IsBuzz(i))
                {
                    retList.Add("Buzz");
                }
                else
                {
                    retList.Add(i);
                }
            }
            return retList;
        }

        private static bool IsBuzz(int i)
        {
            return i % 5 == 0;
        }

        private static bool IsFizz(int i)
        {
            return i % 3 == 0;
        }

        private static bool IsFizzBuzz(int i)
        {
            return i % 3 == 0 && i % 5 == 0;
        }
    }
}
