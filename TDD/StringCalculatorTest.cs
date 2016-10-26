using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        public void ForEmptyString_Add_ReturnsZero()
        {
            var monkey = StringCalculator.GetCalculator();
            var retvalue = monkey.Add("");
            Assert.AreEqual(0, retvalue);
        }
        [TestMethod]
        public void ForSingleNumber_Add_ReturnsValue()
        {
            var monkey = StringCalculator.GetCalculator();
            var retvalue = monkey.Add("1");
            Assert.AreEqual(1, retvalue);
        }
    }

    public class StringCalculator
    {
        public static StringCalculator GetCalculator()
        {
            return new StringCalculator();
        }

        public int Add(string v)
        {
            if (v == "")
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(v);
            }
        }
    }
}
