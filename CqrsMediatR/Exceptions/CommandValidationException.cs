using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CqrsMediatR.Exceptions
{
    public class CommandValidationException : Exception
    {
        public CommandValidationException(string message, Exception inner) : base(message,inner)
        {

        }
    }
}
