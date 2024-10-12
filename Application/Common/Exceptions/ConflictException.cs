using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Common.Exceptions
{
    public class ConflictException : Exception, IServiceException
    {
        public ConflictException(string message) {
            Message = message;
        }
        public HttpStatusCode StatusCode => throw new NotImplementedException();
    
        public string Message {  get;}
    }
}
