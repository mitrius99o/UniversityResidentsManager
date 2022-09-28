using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityResidents
{
    public interface IDataSender
    {
        void SendData(List<Person> personData);
    }
}
