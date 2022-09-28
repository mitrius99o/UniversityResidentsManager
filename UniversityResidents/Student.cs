using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace UniversityResidents
{
    public class Student:Person
    {
        public IEnumerable<int> Marks { get; private set; }
        public int Grant { get; private set; }
        public double AverageMark
        {
            get
            {
                int sum = 0;
                foreach (int m in Marks)  sum += m;
                return (double)sum / Marks.Count();
            }
        }
        public Student(string name, string surName, int grant, List<int> listMarks)
        : base(name, surName)
        {
            Status = "Студент";
            Grant = grant;
            Marks = listMarks;
        }
        public override Int32 GetIncome(Int32 months)
        {
            if (Marks.Any(m => m == 3))
                return 0;
            else
                return Grant*months;
        }
    }
}
