using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UniversityResidents
{
    public class FileDataSender : IDataSender
    {
        string fileName;
        public FileDataSender(string fn)
        {
            fileName = fn;
        }
        public void SendData(List<Person> personData)
        {
            Console.Write("Введите количество месяцев для расчета дохода человека и записи в файл: ");
            int months = int.Parse(Console.ReadLine());
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("Расчет дохода на {0} месяца(ев)", months);
                sw.WriteLine("- - - - - - - - - - - - - - ");
                foreach (Person p in personData)
                    sw.WriteLine("{0};{1};{2};{3}", p.Name, p.SurName, p.Status, p.GetIncome(months));
                sw.WriteLine("- - - - - - - - - - - - - - ");
            }
            Console.WriteLine("Вывод в файл прошел успешно!");
        }
    }
}
