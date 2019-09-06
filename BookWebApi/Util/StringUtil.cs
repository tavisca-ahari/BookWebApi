using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookWebApi.Util
{
    public class StringUtil
    {
        public static bool HasOnlyAlphabets(string data)
        {
            return Regex.IsMatch(data, @"^[a-zA-Z]+$");
        }
    }
}
