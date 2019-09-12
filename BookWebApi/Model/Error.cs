using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApi.Model
{
    public class Error
    {
        public string ErrorCode { get; set; }
        public List<string> ErrorMessage { get; set; }
    }
}
