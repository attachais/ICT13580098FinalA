using ICT13580098FinalA.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT13580098FinalA.Helper
{
    public class DbHelper
    {
        SQLiteConnection db;
        public DbHelper(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Employee>();
        }

        public int AddDetail(Employee emp)
        {
            db.Insert(emp);
            return emp.Id;
        }

        public List<Employee> GetDetail()
        {
            return db.Table<Employee>().ToList();
        }

        public int UpdateDetail(Employee emp)
        {
            return db.Update(emp);
        }

        public int DeleteEmp(Employee emp)
        {
            return db.Delete(emp);
        }
    }
}
