using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityResidents
{
    public class Worker:Person
    {
		public int FixRate { get; private set; }
		public Worker(string name, string surName, int fixRate)
		: base(name, surName)
		{
			Status = "Технический работник";
			FixRate = fixRate;
		}
		public override Int32 GetIncome(Int32 months)
        {
			return FixRate * months;
        }

	}
}
