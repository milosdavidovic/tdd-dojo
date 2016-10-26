using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    [TestClass]
    public class CombinedNumberTest
    {
        [TestMethod]
        public void ForArrayWithNegativeNumber_FindCominedNumber_ReturnsNull()
        {
            var combiner = CombineNumber.GetCombiner();
            var retvalue = combiner.Combine(new int[] { -1, 23, 4, 5 });
            Assert.IsNull(retvalue);
        }
        [TestMethod]
        public void ForEmptyArray_FindCombinedNumber_ReturnsNull()
        {
            var combiner = CombineNumber.GetCombiner();
            var retvalue = combiner.Combine(new int[] { });
            Assert.IsNull(retvalue);
        }
        [TestMethod]
        public void ForNonNegativeNumbers_FindCombinedNumber_ReturnsNonEmptyString()
        {
            var combiner = CombineNumber.GetCombiner();
            var retvalue = combiner.Combine(new int[] { 1, 2, 35, 122 });
            Assert.IsInstanceOfType(retvalue, typeof(string));
            Assert.IsTrue(retvalue != "");
        }
        [TestMethod]
        public void ForNonNegativeNumbers_FindCombinedNumber_ReturnsLargestCombinedNumber()
        {
            var combiner = CombineNumber.GetCombiner();
            var retvalue = combiner.Combine(new int[] { 22, 220, 22, 122 });
            Assert.IsTrue(retvalue != "");
        }
    }

    public class CombineNumber
    {
        public static CombineNumber GetCombiner()
        {
            return new CombineNumber();
        }

        public string Combine(int[] v)
        {
            List<string> templist = new List<string>();
            string retvalue = "";
            if (IsNullOrEmpty(v) || IsContaningNegativeOrZeroNumber(v))
            {
                return null;
            }
            else
            {
                templist.AddRange(v.Select(x => x.ToString()).ToArray());
                templist.Sort();
                templist.Reverse();
                foreach (var a in templist)
                {
                    retvalue += a;
                }
                return retvalue;
            }
        }

        private static bool IsNullOrEmpty(int[] v)
        {
            return v == null || v.Count() == 0;
        }

        private bool IsContaningNegativeOrZeroNumber(int[] ar)
        {
            foreach (var item in ar)
            {
                if (item <= 0)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
