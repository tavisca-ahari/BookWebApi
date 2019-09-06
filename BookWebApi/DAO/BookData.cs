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
            new Book{id=1,name="ABC",category="thriller",price=10,author="ABC"},
            new Book{id=2,name="VBNM",category="comedy",price=20,author="HJK"},
            new Book{id=3,name="PLM",category="tragedy",price=30,author="ERT"},
        };

        public List<Book> Get()
        {
            return bookList;
        }

        public Book GetById(int id)
        {
            foreach (Book book in bookList)
            {
                if (book.id == id)
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
                if (bookList[i].id == id)
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
                if (bookList[i].id == id)
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
