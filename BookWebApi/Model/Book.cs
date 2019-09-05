using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApi.Model
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public int price { get; set; }
        public string author { get; set; }
    }
}

