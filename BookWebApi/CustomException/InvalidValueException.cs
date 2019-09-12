using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApi.CustomException
{
    public class InvalidValueException : Exception
    {
        public string ErrorCode { get; }
        public List<string> ErrorList { get; }

        public InvalidValueException(string ErrorCode, List<string> ErrorList)
        {
            this.ErrorCode = ErrorCode;
            this.ErrorList = ErrorList;
        }
    }
}
