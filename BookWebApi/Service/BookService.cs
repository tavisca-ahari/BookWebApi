using System.Collections.Generic;

using BookWebApi.Model;
using BookWebApi.DAO;
using BookWebApi.CustomException;
using BookWebApi.Validator;
using FluentValidation.Results;
using BookWebApi.Constants;

namespace BookWebApi.Service
{
    public class BookService : IBookService
    {
        private BookData _bookData = new BookData();
        private IdValidator _idValidator = new IdValidator();
        private BookValidator _bookValidator = new BookValidator();

        public List<Book> GetBook()
        {
            return _bookData.Get();
        }

        public Book GetBook(int id)
        {
            Book book = null;
            List<string> errorList = new List<string>();

            ValidationResult validationResult = _idValidator.Validate(id);

            if (validationResult.IsValid)
            {
                book = _bookData.GetById(id);
                if (book == null)
                {
                    errorList.Add("No Book with id " + id + ".");
                    throw new InvalidValueException(ErrorConstants.BookNotPresentErrorCode, errorList);
                }
            }
            else
            {
                foreach (ValidationFailure vf in validationResult.Errors)
                {
                    errorList.Add(vf.ErrorMessage);
                }
                throw new InvalidValueException(ErrorConstants.InvalidIdErrorCode, errorList);
            }

            return book;
        }

        public Book CreateBook(Book book)
        {
            List<string> errorList = new List<string>();
            Book book1 = null;

            ValidationResult validationResult = _bookValidator.Validate(book);

            if (_bookData.GetById(book.Id) != null)
            {
                errorList.Add("Id already exists.");
                throw new InvalidValueException(ErrorConstants.IdAlreadyExistsErrorCode, errorList);
            }

            if (validationResult.IsValid)
            {
                book1 = _bookData.Add(book);
            }
            else
            {
                foreach (ValidationFailure vf in validationResult.Errors)
                {
                    errorList.Add(vf.ErrorMessage);
                }
                throw new InvalidValueException(ErrorConstants.InvalidBookValueErrorCode, errorList);
            }

            return book1;
        }

        public Book UpdateBook(int id, Book book)
        {
            Book book1 = null;
            List<string> errorList = new List<string>();

            ValidationResult bookValidationResult = _bookValidator.Validate(book);
            ValidationResult idValidationResult = _idValidator.Validate(id);

            if (bookValidationResult.IsValid && idValidationResult.IsValid)
            {
                book1 = _bookData.Update(id, book);
                if (book1 == null)
                {
                    errorList.Add("No book with id " + id);
                    throw new InvalidValueException(ErrorConstants.BookNotPresentErrorCode, errorList);
                }
            }
            else
            {
                foreach (ValidationFailure vf in bookValidationResult.Errors)
                {
                    errorList.Add(vf.ErrorMessage);
                }
                foreach (ValidationFailure vf in idValidationResult.Errors)
                {
                    errorList.Add(vf.ErrorMessage);
                }
                string errorCode = ErrorConstants.InternalServerErrorCode;
                if(bookValidationResult.Errors.Count != 0 && idValidationResult.Errors.Count != 0)
                {
                    errorCode = ErrorConstants.InvalidUpdateValueErrorCode;
                }
                else if(bookValidationResult.Errors.Count != 0)
                {
                    errorCode = ErrorConstants.InvalidBookValueErrorCode;
                }
                else
                {
                    errorCode = ErrorConstants.InvalidIdErrorCode;
                }
                throw new InvalidValueException(errorCode, errorList);
            }

            return book1;
        }

        public Book DeleteBook(int id)
        {
            Book book = null;
            List<string> errorList = new List<string>();

            ValidationResult validationResult = _idValidator.Validate(id);

            if (validationResult.IsValid)
            {
                book = _bookData.Delete(id);
                if (book == null)
                {
                    errorList.Add("No book with id " + id);
                    throw new InvalidValueException(ErrorConstants.BookNotPresentErrorCode,errorList);
                }
            }
            else
            {
                foreach (ValidationFailure vf in validationResult.Errors)
                {
                    errorList.Add(vf.ErrorMessage);
                }
                throw new InvalidValueException(ErrorConstants.InvalidIdErrorCode, errorList);
            }
            
            return book;
        }

    }
}
