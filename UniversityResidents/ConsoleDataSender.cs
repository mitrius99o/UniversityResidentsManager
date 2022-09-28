using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityResidents
{
    public class ConsoleDataSender : IDataSender
    {
        public void SendData(List<Person> personData)
        {
            Console.Write("Введите количество месяцев для расчета дохода человека и для вывода в консоль: ");
            int months = int.Parse(Console.ReadLine());
            Console.WriteLine("- - - - - - - - - - - - - - ");
            foreach (Person resident in personData)
            {
                Console.Write("{0} {1} {2} {3}\n", resident.Name, resident.SurName, resident.Status, resident.GetIncome(months));
            }
            Console.WriteLine("- - - - - - - - - - - - - - ");
        }
    }
}
