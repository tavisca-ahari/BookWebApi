using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookWebApi.Service;
using BookWebApi.Model;
using BookWebApi.CustomException;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private BookService bookService = new BookService();

        // GET: api/Book
        [HttpGet]
        public IActionResult Get()
        {
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
            catch (IncorrectIdException Ex)
            {
                return BadRequest(new Error { errorMessage = Ex.Message });
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
            catch (IncorrectIdException Ex)
            {
                return BadRequest(new Error { errorMessage = Ex.Message });
            }
            catch (InvalidValueException Ex)
            {
                return BadRequest(new Error { errorMessage = Ex.Message });
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
            catch (IncorrectIdException Ex)
            {
                return NotFound(new Error { errorMessage = Ex.Message });
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
            catch (IncorrectIdException Ex)
            {
                return NotFound(new Error { errorMessage = Ex.Message });
            }
        }
    }
}
