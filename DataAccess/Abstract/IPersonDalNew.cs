using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace DataAccess.Abstract
{
    public interface IPersonDalNew
    {
        void Add(string name, string surname, long number);
        void Delete(int id);
        void Update(int id, string name, string surname, long number);
        List<Person> GetAll();
    }
}
