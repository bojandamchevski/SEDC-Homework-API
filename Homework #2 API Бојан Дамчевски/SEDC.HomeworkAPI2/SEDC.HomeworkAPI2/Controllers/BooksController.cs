using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.HomeworkAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.HomeworkAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, StaticDb.Books);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpGet("{index}")]
        public ActionResult<Book> Get(int index)
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request, the index can not be negative!");
                }
                if (index >= StaticDb.Books.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Resource with index {index} does not exist!");
                }
                return Ok(StaticDb.Books[index]);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpGet("queryString")]
        public ActionResult<Book> GetByIndex(int index)
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request, the index can not be negative!");
                }
                if (index >= StaticDb.Books.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Resource with index {index} does not exist!");
                }
                return Ok(StaticDb.Books[index]);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpGet("filter")]
        public ActionResult<List<Book>> FilterBooksFromQuery(string author, string title)
        {
            try
            {
                if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "You have to send at least one filter parameter!");
                }
                if (string.IsNullOrEmpty(author))
                {
                    List<Book> booksDb = StaticDb.Books.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
                    return StatusCode(StatusCodes.Status200OK, booksDb);
                }
                if (string.IsNullOrEmpty(title))
                {
                    List<Book> booksDb = StaticDb.Books.Where(x => x.Author.ToLower().Contains(author.ToLower())).ToList();
                    return StatusCode(StatusCodes.Status200OK, booksDb);
                }
                List<Book> filteredBooks = StaticDb.Books.Where(x => x.Author.ToLower().Contains(author.ToLower())
                                                             && x.Title.ToLower().Contains(title.ToLower())).ToList();
                return StatusCode(StatusCodes.Status200OK, filteredBooks);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpPost("fromBody")]
        public IActionResult Post([FromBody] Book book)
        {
            try
            {
                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "Book was added");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpPost("Titles")]
        public ActionResult<List<string>> PostTitles([FromBody] List<Book> books)
        {
            try
            {
                List<string> titles = books.Select(x => x.Title).ToList();
                return StatusCode(StatusCodes.Status200OK, titles);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }
    }
}
