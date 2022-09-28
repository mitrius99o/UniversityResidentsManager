using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace UniversityResidents
{
    public class Repository
    {
        IDataLoader dataLoader;
        IDataSender dataSender;
        List<Person> universityResidents;
        public Repository(IDataLoader loader, IDataSender sender)
        {
            dataLoader = loader;
            dataSender = sender;
        }
        public void ChangeSender(IDataSender newDataSender)
        {
            dataSender = newDataSender;
        }
        public Person GetMaxIncomePerson(int months)
        {
            var maxIncome = universityResidents.Max(r => r.GetIncome(months));
            return universityResidents.Find(r => r.GetIncome(months) == maxIncome);
        }
        public List<Student> GetExcellentStudents()
        {
            var students = universityResidents.FindAll(r => r.GetType() == typeof(Student)).Select(p=>p as Student);
            return students.Where(s => s.Marks.Count(m => m == 5) == 8).ToList();
        }
        public Worker GetMaxFixRateWorker()
        {
            var workers = universityResidents.FindAll(r => r.GetType() == typeof(Worker)).Select(p => p as Worker);
            var maxFixRate = workers.Max(w => w.FixRate);
            return workers.ToList().Find(w => w.FixRate == maxFixRate);
        }
        public List<Student> GetStudents()
        {
            return universityResidents
                .FindAll(r => r.GetType() == typeof(Student))
                .Select(p => p as Student)
                .ToList();
        }
        public void LoadData()
        {
            dataLoader.LoadData(ref universityResidents);
        }

        public void SendData()
        {
            dataSender.SendData(universityResidents);
        }
    }
}
