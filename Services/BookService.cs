using Microsoft.EntityFrameworkCore;
using BooksWebpage.Data;
using BooksWebpage.Utils;

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
    {
        var book = _db.Books
            .Include(b => b.Chapters)
                .ThenInclude(c => c.Comments.Where(comment => comment.ParentId == null))
            .Include(b => b.Comments.Where(c => c.ChapterId == null && c.ParentId == null))
                .ThenInclude(comment => comment.Replys!) 
            .AsNoTracking()
            .SingleOrDefault(b => b.Id == id);

        if(book == null)
            return book;
        
        CommentHelpers.ReplaceDeletedCommentText(book.Comments);

        if (book.Chapters != null)
        {
            foreach (var chapter in book.Chapters)
            {
                CommentHelpers.ReplaceDeletedCommentText(chapter.Comments);
            }
        }

        return book;
    }

    public Book Add(Book book)
    {
        _db.Books.Add(book);
        _db.SaveChanges();
        return book;
    }
}
