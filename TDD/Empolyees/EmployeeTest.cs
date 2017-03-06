using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Empolyees
{
    // Employee is the base class
    // Fileds/Properties:
    // Name
    // RegularHourRate
    // OvertimeHourRate
    // WeeklyWorkingHours
    // OvertimeHours

    // Methods:
    // GiveBonus
    // GivePromotion
    // Fire
    // CalculatePay

    // Manager

    // SalesPerson


    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void ForDeveloper_GetPaycheck_ReturnsAmount()
        {
            var dev = new Developer("Pera", 10, 15, 40);
            var monkey = dev.GetPaycheck();
            Assert.AreEqual(400, monkey);
        }

        [TestMethod]
        public void ForManager_GetPaycheck_ReturnsAmount()
        {
            var dev = new Menager("Mika", 15, 15, 40);
            var monkey = dev.GetPaycheck();
            Assert.AreEqual(600, monkey);
        }

    }

    public class Developer : Employee
    {

        public Developer(string name, int normalRate, int overtimeRate, int weeklyHours)
                        : base(name, normalRate, overtimeRate, weeklyHours)
        {

        }

        public override int GetPaycheck()
        {
            return _regularHourlyRate * _weeklyWorkingHours + _overtimeHourlyRate * _weeklyOvertimeWorkingHours;
        }
    }

    public class Menager : Employee
    {

        public Menager(string name, int normalRate, int overtimeRate, int weeklyHours)
            : base(name, normalRate, overtimeRate, weeklyHours)
        {

        }

        public override int GetPaycheck()
        {
            return _regularHourlyRate * _weeklyWorkingHours + _overtimeHourlyRate * _weeklyOvertimeWorkingHours;
        }
    }

    public abstract class Employee
    {
        protected string _name;
        protected int _regularHourlyRate;
        protected int _overtimeHourlyRate;
        protected int _weeklyWorkingHours;
        protected int _weeklyOvertimeWorkingHours;

        protected Employee(string name, int normalRate, int overtimeRate, int weeklyHours)
        {
            this._name = name;
            this._regularHourlyRate = normalRate;
            this._overtimeHourlyRate = overtimeRate;
            this._weeklyWorkingHours = weeklyHours;
            this._weeklyOvertimeWorkingHours = 0;
        }

        public virtual int GetPaycheck()
        {
            return _regularHourlyRate * _weeklyWorkingHours + _overtimeHourlyRate * _weeklyOvertimeWorkingHours;
        }
    }
}
