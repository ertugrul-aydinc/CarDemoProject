﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        public bool IsSuccess { get; }
        public string Message { get; }
    }
}
