
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBooksService _booksService;

    public BookController(IBooksService booksService)
    {
        _booksService = booksService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookResponse>>> GetBooks()
    {
        var books = await _booksService.GetAllBooks();

        var response = books.Select(x => new BookResponse(x.Id, x.Title, x.Description, x.Price));
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateBooks([FromBody] BookRequest request)
    {
        var (book,error) = 
            Book.Create(Guid.NewGuid(), request.title, request.description,  request.price);
        
        if(!string.IsNullOrEmpty(error))
        {
           return BadRequest(error);
        }

        var bookId = await _booksService.CreateBook(book);

        return Ok(bookId);
    }
    [HttpPost("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BookRequest request)
    {        
        var bookId = await _booksService.UpdateBook(id, request.title,request.description, request.price);
        return Ok(bookId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteBook(Guid id)
    {        
        var bookId = await _booksService.DeleteBook(id);
        return Ok(bookId);
    }
}
