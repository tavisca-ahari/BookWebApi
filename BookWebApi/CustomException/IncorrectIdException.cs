using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApi.CustomException
{
    public class IncorrectIdException : Exception
    {
        public IncorrectIdException(string Message) : base(Message)
        {

        }
    }
}
