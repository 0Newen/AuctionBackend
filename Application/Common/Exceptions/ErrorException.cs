﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Common.Exceptions
{
    public class ErrorException
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details {  get; set; }
    }
}
