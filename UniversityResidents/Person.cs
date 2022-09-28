using System;

namespace UniversityResidents
{
    public abstract class Person
    {
		public string Name { get; protected set; }
		public string SurName { get; protected set; }
		public string Status { get; protected set; }

		public Person(string name, string surName)
		{
			Name = name;
			SurName = surName;
		}
		public abstract Int32 GetIncome(Int32 months);
	}
}
