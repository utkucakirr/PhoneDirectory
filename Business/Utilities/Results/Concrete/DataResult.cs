using System;
using System.Collections.Generic;
using System.Text;
using Business.Utilities.Results.Abstract;

namespace Business.Utilities.Results.Concrete
{
    public class DataResult<T>:Result,IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
