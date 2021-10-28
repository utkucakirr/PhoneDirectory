using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.FluentValidation;
using Business.Utilities.Results.Abstract;
using Business.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities;
using FluentValidation.Results;

namespace Business.Concrete
{
    public class PersonManager:IPersonService
    {
        private IPersonDal _personDal;
        //private IPersonDalNew _personDalNew;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        //public PersonManager(IPersonDalNew personDal)
        //{
        //    _personDalNew = personDal;
        //}

        public IResult Add(Person person)
        {
            PersonValidator validator = new PersonValidator();
            ValidationResult results = validator.Validate(person);
            //var result = CheckIfPersonExists(person);
            //var result2 = CheckIfNumberExists(person);
            if (results.IsValid )//&& !result &&!result2)
            {
                _personDal.Add(person);
                return new Result(true, "Person added!");
            }
            //foreach (var failure in results.Errors)
            //{
            //    Console.WriteLine(failure.ErrorMessage);
            //}
            return new Result(false, "The person or number you are trying to add is already exists.");
        }

        public IResult Update(Person person)
        {
            PersonValidator validator = new PersonValidator();
            ValidationResult results = validator.Validate(person);
            //var result = CheckIfPersonExists(person);
            //var result2 = CheckIfNumberExists(person);
            if (results.IsValid)// && !result && !result2)
            {
                _personDal.Update(person);
                return new Result(true, "Person updated!");
            }
            //foreach (var failure in results.Errors)
            //{
            //    Console.WriteLine(failure.ErrorMessage);
            //}
            return new Result(false, "The person or number you are trying to add is already exists.");
        }

        public IResult Delete(Person person)
        {
            try
            {
                _personDal.Delete(person);

                return new Result(true, "Person deleted.");
            }
            catch (Exception e)
            {

            }

            return new Result(false, "failed");
        }

        public IDataResult<List<Person>> GetAll()
        {
            return new SuccessDataResult<List<Person>>(_personDal.GetAll(), "Persons listed successfully");
        }

        public IDataResult<List<Person>> GetByName(string name)
        {
            var result = _personDal.GetAll(p => p.PersonName.Contains(name));
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Person>>(result, "Girdiginiz kelimeyi iceren kisiler bulundu!");
            }

            return new ErrorDataResult<List<Person>>("Kisi listenizde girdiğiniz kelimeyi iceren kisi bulunamadi!");
        }

        public IDataResult<List<Person>> GetByNumber(long number)
        {
            var result = _personDal.GetAll(p => p.Number.Equals(number));
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Person>>(result, "Girdiginiz numaranin ait oldugu kisi bulundu!");
            }

            return new ErrorDataResult<List<Person>>(
                "Kisi listenizde girdiginiz numarayi kullanan bir kisi bulunamadi.");
        }

        public List<Person> GetPersons()
        {
            return _personDal.GetAll();
        }

        private bool CheckIfPersonExists(Person person)
        {
            var result = _personDal
                .GetAll(p => p.PersonName == person.PersonName && p.PersonSurname == person.PersonSurname).Any();
            return result;
        }

        private bool CheckIfNumberExists(Person person)
        {
            var result = _personDal
                .GetAll(p => p.Number==person.Number).Any();
            return result;
        }
    }
}
