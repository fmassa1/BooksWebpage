using Microsoft.EntityFrameworkCore;
using BooksWebpage.Data;

public class BookService : IBookService
{
    private readonly ApplicationDbContext _db;

    public BookService(ApplicationDbContext db)
    {
        _db = db;
    }

    public IEnumerable<Book> GetAll()
        => _db.Books.AsNoTracking().ToList();

    public Book? GetById(int id)
        => _db.Books.Find(id);

    public Book Add(Book book)
    {
        _db.Books.Add(book);
        _db.SaveChanges();
        return book;
    }
}
