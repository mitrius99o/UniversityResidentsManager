using System;
using UniversityResidents;
using System.Collections.Generic;
using System.Linq;

namespace UniversityResidentsCManager
{
    class Program
    {
        static void PrintResidentsCollection(List<Person> dataCollection)
        {
            foreach (Person p in dataCollection)
                Console.WriteLine("{0} {1} {2} {3}", p.Name, p.SurName, p.Status);
            if(dataCollection.Count()==0)
                Console.WriteLine("Нет таких людей :(");
        }
        static void Main(string[] args)
        {
            ExcelDataLoader excelLoader = new ExcelDataLoader(@"C:\Users\Dmitry\Documents\Student3.xlsx");
            ConsoleDataSender consoleSender = new ConsoleDataSender();
            Repository dataRepository = new Repository(excelLoader, consoleSender);

            dataRepository.LoadData();
            dataRepository.SendData();

            dataRepository.ChangeSender(new FileDataSender(@"C:\Users\Dmitry\Documents\student3.txt"));
            dataRepository.SendData();

            //Дополнительная фильтрация данных

            //1. Человек с максимальным доходом за 6 месяцев
            Person p = dataRepository.GetMaxIncomePerson(6);
            Console.WriteLine("\n---Самый максимальный доход за 6 месяцев---");
            Console.WriteLine("{0} {1} {2} {3}", p.Name, p.SurName, p.Status, p.GetIncome(6));

            //2. Студенты-отличники
            Console.WriteLine("\n---Студенты-отличники---");
            PrintResidentsCollection(dataRepository.GetExcellentStudents().ToList<Person>());

            //3. Работник, чья фиксированная ставка самая большая
            Worker w = dataRepository.GetMaxFixRateWorker();
            Console.WriteLine("\n---Самая большая фиксированная ставка---");
            Console.WriteLine("{0} {1} {2} {3}", w.Name, w.SurName, w.Status, w.FixRate);

            //4. Средний балл каждого студента
            Console.WriteLine("\n---Студенты и их средние баллы---");
            var students = dataRepository.GetStudents();
            foreach(Student s in students)
                Console.WriteLine("{0} {1} {2} {3}", s.Name, s.SurName, s.Status, s.AverageMark);
        }
    }
}
