using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookWebApi.Model;

namespace BookWebApi.DAO
{
    public class BookData
    {
        public static List<Book> bookList = new List<Book>()
        {
            new Book{Id=1,Name="ABC",Category="thriller",Price=10,Author="ABC"},
            new Book{Id=2,Name="VBNM",Category="comedy",Price=20,Author="HJK"},
            new Book{Id=3,Name="PLM",Category="tragedy",Price=30,Author="ERT"},
        };

        public List<Book> Get()
        {
            return bookList;
        }

        public Book GetById(int id)
        {
            foreach (Book book in bookList)
            {
                if (book.Id == id)
                    return book;
            }
            return null;
        }

        public Book Add(Book book)
        {
            bookList.Add(book);
            return book;
        }

        public Book Update(int id, Book book)
        {
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Id == id)
                {
                    bookList[i] = book;
                    return book;
                }
            }
            return null;
        }

        public Book Delete(int id)
        {
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Id == id)
                {
                    Book book = bookList[i];
                    bookList.RemoveAt(i);
                    return book;
                }
            }
            return null;
        }

    }
}
