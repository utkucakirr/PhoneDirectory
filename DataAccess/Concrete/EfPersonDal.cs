using System;
using System.Collections.Generic;
using System.Text;
using ConsoleUI;
using DataAccess.Abstract;
using Entities;

namespace DataAccess.Concrete
{
    public class EfPersonDal:EfEntityRepository<Person,PhoneContext>,IPersonDal
    {

    }
}
