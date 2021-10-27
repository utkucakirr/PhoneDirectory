using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using FluentValidation;

namespace Business.FluentValidation
{
    public class PersonValidator:AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(Person => Person.PersonName).NotNull().WithMessage("Person name can't be null.");
            RuleFor(Person => Person.PersonName).MinimumLength(2)
                .WithMessage("Person name must be at least two characters.");
            RuleFor(Person => Person.Number).NotNull().WithMessage("Person number can't be null");
            RuleFor(Person => Person.Number).GreaterThan(0);
        }
    }
}
