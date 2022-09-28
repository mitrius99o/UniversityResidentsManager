using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityResidents
{
    public interface IDataLoader
    {
        void LoadData(ref List<Person> personData);
    }
}
