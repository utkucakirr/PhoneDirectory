using System;
using Entities.Abstract;

namespace Entities
{
    public class Person:IEntity
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public long Number { get; set; }
    }
}
