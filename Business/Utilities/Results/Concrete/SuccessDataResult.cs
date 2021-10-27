using System;
using System.Collections.Generic;
using System.Text;
using Business.Utilities.Results.Abstract;

namespace Business.Utilities.Results.Concrete
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message) : base(data, true, message)
        {

        }
    }
}
