using System;
using System.Collections.Generic;
using System.Text;
using Business.Utilities.Results.Abstract;
using Entities;

namespace Business.Abstract
{
    public interface IPersonService
    {
        IResult Add(Person person);
        IResult Update(Person person);
        IResult Delete(Person person);
        IDataResult<List<Person>> GetAll();
        IDataResult<List<Person>> GetByName(string name);
        IDataResult<List<Person>> GetByNumber(long number);
        List<Person> GetPersons();
    }
}
