using System;
using System.Collections.Generic;
using System.Text;
using Business.Utilities.Results.Abstract;

namespace Business.Utilities.Results.Concrete
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
    }
}
