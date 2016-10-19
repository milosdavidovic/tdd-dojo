using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Xunit;
namespace TDD
{
    [TestClass]
    public class LeapYearCheckerTest
    {
        [TestMethod]
        public void IsLeapYear_ForTypicalCommYear_ReturnsFalse()
        {
            LeapYearChecker checker = new LeapYearChecker();
            bool result = checker.IsLeapYear(2001);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void IsLeapYear_ForTypicalLeapYear_ReturnsTrue()
        {
            var checker = LeapYearChecker.GetLeapYearChecker();
            var result = checker.IsLeapYear(1996);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsLeapYear_ForAtypicalCommonYear_ReturnsTrue()
        {
            var checker = LeapYearChecker.GetLeapYearChecker();
            var result = checker.IsLeapYear(1900);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsLeapYear_ForAtypicalLeapYear_ReturnsFalse()
        {
            var checker = LeapYearChecker.GetLeapYearChecker();
            var result = checker.IsLeapYear(1900);
            Assert.IsFalse(result);
        }
    }

    class LeapYearChecker
    {
        public static LeapYearChecker GetLeapYearChecker()
        {
            return new LeapYearChecker();
        }
        internal bool IsLeapYear(int year)
        {
            if (IsCommonLeapYear(year) && !IsAtypicalCommonYear(year) || IsAtypicalLeapYear(year))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsCommonLeapYear(int year)
        {
            return year % 4 == 0;
        }

        private bool IsAtypicalCommonYear(int year)
        {
            return year % 100 == 0;
        }

        private bool IsAtypicalLeapYear(int year)
        {
            return year % 400 == 0;

        }
    }
}
