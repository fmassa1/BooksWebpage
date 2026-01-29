using Microsoft.EntityFrameworkCore;
using BooksWebpage.Data;

public class ChapterService : IChapterService
{
    private readonly ApplicationDbContext _db;

    public ChapterService(ApplicationDbContext db)
    {
        _db = db;
    }

    public IEnumerable<Chapter> GetAllForBook(int bookId)
        => _db.Chapters
          .Where(c => c.BookId == bookId)
          .AsNoTracking()
          .ToList();

    public Chapter? GetByNumber(int bookId, int num)
        => _db.Chapters
          .AsNoTracking()
          .SingleOrDefault(c => c.BookId == bookId && c.Number == num);
          

    public Chapter Add(Chapter chapter)
    {
        _db.Chapters.Add(chapter);
        _db.SaveChanges();
        return chapter;
    }

    public bool Remove(int id)
    {
        var chapter = _db.Chapters.Find(id);
        if (chapter == null)
            return false;

        _db.Chapters.Remove(chapter);
        _db.SaveChanges();
        return true;
    }
}