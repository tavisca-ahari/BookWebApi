using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookWebApi.Model;

namespace BookWebApi.Service
{
    interface IBookService
    {
        List<Book> GetBook();

        Book GetBook(int id);

        Book CreateBook(Book book);

        Book UpdateBook(int id, Book book);

        Book DeleteBook(int id);
    }
}
