using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD
{
    [TestClass]
    public class FuzzBuzzTest
    {
        [TestMethod]
        public void FuzzBuzz_ForDefinedNuberOfIterations_ReturnsArrayOfNumberOfIterationsSize()
        {
            var fuzzBuzzer = FuzzBuzz.GetFuzzBuzzer();
            var numberOfLinesPrinted = fuzzBuzzer.DoFuzzBuzz(20);
            Assert.AreEqual(numberOfLinesPrinted.Count(), 20);
        }
        [TestMethod]
        public void FuzzBuzz_ForMultipleOfThree_ReturnsFuzzOnRightPlaces()
        {
            var fuzzBuzzer = FuzzBuzz.GetFuzzBuzzer();
            List<object> fuzzArray = fuzzBuzzer.DoFuzzBuzz(100);
            Assert.AreEqual("Fuzz", (string)fuzzArray[2]);
            Assert.AreEqual("Fuzz", (string)fuzzArray[8]);
            Assert.AreEqual("Fuzz", (string)fuzzArray[26]);
        }
        [TestMethod]
        public void FuzzBuzz_ForMultipleOfFive_ReturnsBuzzOnRightPlaces()
        {
            var fuzzBuzzer = FuzzBuzz.GetFuzzBuzzer();
            List<object> fuzzArray = fuzzBuzzer.DoFuzzBuzz(100);
            Assert.AreEqual("Buzz", (string)fuzzArray[4]);
            Assert.AreEqual("Buzz", (string)fuzzArray[99]);
            Assert.AreEqual("Buzz", (string)fuzzArray[24]);
        }

        [TestMethod]
        public void FuzzBuzz_ForMultipleOfFiveAndThree_ReturnsFuzzBuzzOnRightPlaces()
        {
            var fuzzBuzzer = FuzzBuzz.GetFuzzBuzzer();
            List<object> fuzzArray = fuzzBuzzer.DoFuzzBuzz(100);
            Assert.AreEqual("FuzzBuzz", (string)fuzzArray[14]);
            Assert.AreEqual("FuzzBuzz", (string)fuzzArray[29]);
            Assert.AreEqual("FuzzBuzz", (string)fuzzArray[59]);
        }

    }

     class FuzzBuzz
    {
        public FuzzBuzz()
        {

        }

        public static FuzzBuzz GetFuzzBuzzer()
        {
            return new FuzzBuzz();
        }

        public List<object> DoFuzzBuzz(int nuberOfIterations)
        {
            List<object> retList = new List<object>();
            for (int i = 1; i < nuberOfIterations + 1; i++)
            {
                if (IsFuzzBuzz(i))
                {
                    retList.Add("FuzzBuzz");
                }
                else if (IsFuzz(i))
                {
                    retList.Add("Fuzz");
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

        private static bool IsFuzz(int i)
        {
            return i % 3 == 0;
        }

        private static bool IsFuzzBuzz(int i)
        {
            return i % 3 == 0 && i % 5 == 0;
        }
    }
}
