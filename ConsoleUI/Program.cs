using System;
using Business.Concrete;
using DataAccess.Concrete;
using Entities;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonManager personManager = new PersonManager(new EfPersonDal());

            Person person = new Person()
            {
                Number = 5379139613, PersonName = "Utku", PersonSurname = "Cakir"
            };

            Console.WriteLine(personManager.Add(person));
            
            Console.WriteLine(personManager.GetAll().Message);
            foreach (var item in personManager.GetAll().Data)
            {
                Console.WriteLine(item.PersonName+item.PersonSurname+item.Number);
            }
        }
    }
}
