using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD
{
    [TestClass]
    public class StatsCalculatorTest
    {
        [TestMethod]
        public void GetMinValueCalc_ForNull_ReturnZero()
        {
            var valueCalc = CalcStats.GetValueCalc();
            var result = valueCalc.GetMinValue(null);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void GetMinValueCalc_ForEmptyArray_ReturnZero()
        {
            var valueCalc = CalcStats.GetValueCalc();
            var result = valueCalc.GetMinValue(new int[] { });
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void GetMinCalc_ForLegitArray_ReturnMinValue()
        {
            var valueCalc = CalcStats.GetValueCalc();
            var result = valueCalc.GetMinValue(new int[] {1001, 5, 8, 12, 10, 99 });
            Assert.AreEqual(5, result);
        }
        [TestMethod]
        public void GetMaxCalc_ForNull_ReturnZero()
        {
            var valueCalc = CalcStats.GetValueCalc();
            var result = valueCalc.GetMaxValue(null);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetMaxCalc_ForEmptyArray_ReturnZero()
        {
            var valueCalc = CalcStats.GetValueCalc();
            var result = valueCalc.GetMaxValue(new int[] { });
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetMaxCalc_ForLegitArray_ReturnMaxValue()
        {
            var valueCalc = CalcStats.GetValueCalc();
            var result = valueCalc.GetMaxValue(new int[] { 1001, 5, 8, 12, 10, 9 });
            Assert.AreEqual(1001, result);
        }

        [TestMethod]
        public void GetCount_ForNull_ReturnZero()
        {
            var valueCalc = CalcStats.GetValueCalc();
            var result = valueCalc.GetCountValue(null);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetCount_ForEmptyArray_ReturnZero()
        {
            var valueCalc = CalcStats.GetValueCalc();
            var result = valueCalc.GetCountValue(new int[] { });
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void GetCount_ForLegitArray_ReturnCount()
        {
            var valueCalc = CalcStats.GetValueCalc();
            var result = valueCalc.GetCountValue(new int[] { 1,2,3,4,43645,35});
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void GetAverage_ForNull_ReturnZero()
        {
            var valueCalc = CalcStats.GetValueCalc();
            var result = valueCalc.GetAverageValue(null);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetAverage_ForEmptyArray_ReturnZero()
        {
            var valueCalc = CalcStats.GetValueCalc();
            var result = valueCalc.GetAverageValue(new int[] { });
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void GetAverage_ForLegitArray_ReturnAverage()
        {
            var valueCalc = CalcStats.GetValueCalc();
            var result = valueCalc.GetAverageValue(new int[] { 1, 2, 3, 4, 5, 6 });
            Assert.AreEqual(3.5, result);
        }
}
    class CalcStats
    {
        public static CalcStats GetValueCalc()
        {
            return new CalcStats();
        }
        public int GetMinValue(int [] array)
        {
            if(IsValidArray(array))
            {
                return array.Min();
            }
            return 0;
        }
        public int GetMaxValue(int [] array)
        {
            if (IsValidArray(array))
            {
                return array.Max();
            }
            return 0;
        }
        private bool IsValidArray(int[] array)
        {
            if(array == null || array.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int GetCountValue(int [] array)
        {
            if (IsValidArray(array))
            {
                return array.Count();
            }
            return 0;
        }

        public double GetAverageValue(int[] array)
        {
            if (IsValidArray(array))
            {
                return array.Average();
            }
            return 0;
        }
    }
}
