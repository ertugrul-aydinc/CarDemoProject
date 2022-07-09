using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool ısSuccess,string message):this(ısSuccess)
        {
            Message = message;
        }
        public Result(bool ısSuccess)
        {
            IsSuccess = ısSuccess;
        }

        public bool IsSuccess { get; }

        public string Message { get; }
    }
}
