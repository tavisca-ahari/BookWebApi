using System;
using Xunit;

using BookWebApi.Model;
using BookWebApi.Service;
using BookWebApi.CustomException;
using System.Collections.Generic;

namespace BookWebApiTest
{
    public class UnitTest1
    {
        private BookService bookService = new BookService();

        [Fact]
        public void TestGetAllBook()
        {
            int Expected = 3;
            List<Book> Actual = bookService.GetBook();
            Assert.Equal(Expected, Actual.Count);
        }

        [Fact]
        public void TestGetBookValid()
        {
            Book Expected = new Book { id = 3, name = "PLM", category = "tragedy", price = 30, author = "ERT" };
            Book Actual = bookService.GetBook(3);
            Assert.Equal(Expected.name, Actual.name);
        }

        [Fact]
        public void TestGetBookInValid()
        {
            try
            {
                Book book = bookService.GetBook(-1);
            }
            catch (IncorrectIdException Ex)
            {
                Assert.Equal("Invalid Id, Id should be a positive number.", Ex.Message);
            }
        }

        [Fact]
        public void TestAddBookValid()
        {
            Book Expected = new Book { id = 4, name = "HJK", category = "thriller", price = 110, author = "ABC" };
            Book Actual = bookService.CreateBook(Expected);
            Assert.Equal(Expected, Actual);
        }

        [Fact]
        public void TestAddBookInValidString()
        {
            try
            {
                Book Expected = new Book { id = 4, name = "HJK23", category = "thriller", price = 110, author = "ABC" };
                Book Actual = bookService.CreateBook(Expected);
            }
            catch (InvalidValueException Ex)
            {
                Assert.Equal("String Values should contain only Alphabets.", Ex.Message);
            }

        }

        [Fact]
        public void TestAddBookInValidId()
        {
            try
            {
                Book Expected = new Book { id = -4, name = "HJK", category = "thriller", price = 110, author = "ABC" };
                Book Actual = bookService.CreateBook(Expected);
            }
            catch (IncorrectIdException Ex)
            {
                Assert.Equal("Invalid Id, Id should be a positive number.", Ex.Message);
            }

        }

        [Fact]
        public void TestAddBookInValidPrice()
        {
            try
            {
                Book Expected = new Book { id = 4, name = "HJK", category = "thriller", price = -110, author = "ABC" };
                Book Actual = bookService.CreateBook(Expected);
            }
            catch (InvalidValueException Ex)
            {
                Assert.Equal("Price should be positive.", Ex.Message);
            }

        }

        [Fact]
        public void TestUpdateBookValid()
        {

            Book Expected = new Book { id = 2, name = "OKN", category = "thriller", price = 110, author = "ABC" };
            Book book = bookService.UpdateBook(2, Expected);
            Book Actual = bookService.GetBook(2);
            Assert.Equal(Expected, Actual);

        }


        [Fact]
        public void TestDeleteBookValid()
        {

            int Expected = bookService.GetBook().Count - 1;
            Book book = bookService.DeleteBook(1);
            int Actual = bookService.GetBook().Count;
            Assert.Equal(Expected, Actual);

        }

    }
}

