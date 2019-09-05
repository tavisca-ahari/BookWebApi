using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApi.CustomException
{
    public class InvalidValueException : Exception
    {
        public InvalidValueException(string Message) : base(Message)
        {

        }
    }
}
