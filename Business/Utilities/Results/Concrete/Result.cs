using System;
using System.Collections.Generic;
using System.Text;
using Business.Utilities.Results.Abstract;

namespace Business.Utilities.Results.Concrete
{
    public class Result:IResult
    {
        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; }
        public string Message { get; }
    }
}
