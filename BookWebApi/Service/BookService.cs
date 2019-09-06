using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using BookWebApi.Model;
using BookWebApi.DAO;
using BookWebApi.CustomException;
using BookWebApi.Util;

namespace BookWebApi.Service
{
    public class BookService : IBookService
    {
        private BookData bookData = new BookData();

        public List<Book> GetBook()
        {
            return bookData.Get();
        }

        public Book GetBook(int id)
        {
            if (id < 0)
            {
                throw new IncorrectIdException("Invalid Id, Id should be a positive number.");
            }
            Book book = bookData.GetById(id);
            if (book == null)
            {
                throw new IncorrectIdException("No Book with id " + id + ".");
            }
            return book;
        }

        public Book CreateBook(Book book)
        {
            if (book.id < 0)
            {
                throw new IncorrectIdException("Invalid Id, Id should be a positive number.");
            }
            if (!StringUtil.HasOnlyAlphabets(book.name) || !StringUtil.HasOnlyAlphabets(book.category) || !StringUtil.HasOnlyAlphabets(book.author))
            {
                throw new InvalidValueException("String Values should contain only Alphabets.");
            }
            if (book.price < 0)
            {
                throw new InvalidValueException("Price should be positive.");
            }
            if (bookData.GetById(book.id) != null)
            {
                throw new IncorrectIdException("Id already exists.");
            }
            return bookData.Add(book);
        }

        public Book UpdateBook(int id, Book book)
        {
            Book book1 = bookData.Update(id, book);
            if (book1 == null)
            {
                throw new IncorrectIdException("No book with id " + id + ".");
            }
            return book1;
        }

        public Book DeleteBook(int id)
        {
            Book book = bookData.Delete(id);
            if (book == null)
            {
                throw new IncorrectIdException("No book with id " + id + ".");
            }
            return book;
        }

    }
}
