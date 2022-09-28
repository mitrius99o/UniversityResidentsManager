using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityResidents
{
    public class Teacher:Person
    {
        public int HourRate { get; private set; }
        public int Hours { get; private set; }
        public Teacher(string name, string surName, int hourRate, int hours)
        : base(name, surName)
        {
            Status = "Преподаватель";
            HourRate = hourRate;
            Hours = hours;
        }
        public override Int32 GetIncome(Int32 months)
        {
            double weekHours = (double)Hours / 7;
            if (weekHours > 40)
                return -1;
            else
                return Hours * HourRate * months;
        }
    }
}
