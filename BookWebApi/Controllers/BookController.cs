using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookWebApi.Service;
using BookWebApi.Model;
using BookWebApi.CustomException;
using BookWebApi.Constants;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(BookController));
        private BookService bookService = new BookService();

        // GET: api/Book
        [HttpGet]
        public IActionResult Get()
        {
            log.Debug("Inside Get All Books endpoint.");
            return Ok(bookService.GetBook());
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(bookService.GetBook(id));
            }
            catch (InvalidValueException Ex)
            {
                if (Ex.ErrorCode.Equals(ErrorConstants.BookNotPresentErrorCode))
                {
                    log.Error("Get Book exception for id " + id, Ex);
                    return NotFound(new Error { ErrorCode = Ex.ErrorCode, ErrorMessage = Ex.ErrorList });
                }
                else
                {
                    log.Error("Invalid Id - "+id, Ex);
                    return BadRequest(new Error { ErrorCode = Ex.ErrorCode, ErrorMessage = Ex.ErrorList });
                }
            }
        }

        // POST: api/Book
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            try
            {
                return Ok(bookService.CreateBook(book));
            }
            catch (InvalidValueException Ex)
            {
                return BadRequest(new Error { ErrorCode = Ex.ErrorCode, ErrorMessage = Ex.ErrorList });
            }
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            try
            {
                return Ok(bookService.UpdateBook(id, book));
            }
            catch (InvalidValueException Ex)
            {
                if (Ex.ErrorCode.Equals(ErrorConstants.BookNotPresentErrorCode))
                {
                    return NotFound(new Error { ErrorCode = Ex.ErrorCode, ErrorMessage = Ex.ErrorList });
                }
                else
                {
                    return BadRequest(new Error { ErrorCode = Ex.ErrorCode, ErrorMessage = Ex.ErrorList });
                }
            }
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(bookService.DeleteBook(id));
            }
            catch (InvalidValueException Ex)
            {
                if (Ex.ErrorCode.Equals(ErrorConstants.BookNotPresentErrorCode))
                {
                    return NotFound(new Error { ErrorCode = Ex.ErrorCode, ErrorMessage = Ex.ErrorList });
                }
                else
                {
                    return BadRequest(new Error { ErrorCode = Ex.ErrorCode, ErrorMessage = Ex.ErrorList });
                }
            }
        }
    }
}
