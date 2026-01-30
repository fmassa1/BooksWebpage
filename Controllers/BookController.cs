using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _books;

    public BooksController(IBookService books)
    {
        _books = books;
    }

    [HttpGet]
    public IActionResult GetAll()
        => Ok(_books.GetAll());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var book = _books.GetById(id, includeChapters: true);
        return book is null ? NotFound() : Ok(book);
    }

    [HttpPost]
    public IActionResult Create(Book book)
        => Ok(_books.Add(book));
}