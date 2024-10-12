using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Common.Helpers
{
    public class GenericResult<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; }
    }
}
