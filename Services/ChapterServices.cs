using Microsoft.EntityFrameworkCore;
using BooksWebpage.Data;
using BooksWebpage.Utils;

public class ChapterService : IChapterService
{
    private readonly ApplicationDbContext _db;

    public ChapterService(ApplicationDbContext db)
    {
        _db = db;
    }

    public IEnumerable<Chapter> GetAllForBook(int bookId)
        => _db.Chapters
          .Include(c => c.Comments!.Where(comment => comment.ParentId == null))
            .ThenInclude(comment => comment.Replys!) 
          .Where(c => c.BookId == bookId)
          .AsNoTracking()
          .ToList();

    public Chapter? GetByNumber(int bookId, int num)
    {
        var chapter = _db.Chapters
          .Include(c => c.Comments!.Where(comment => comment.ParentId == null))
            .ThenInclude(comment => comment.Replys!) 
          .AsNoTracking()
          .SingleOrDefault(c => c.BookId == bookId && c.Id == num);

        if(chapter != null) {
            CommentHelpers.ReplaceDeletedCommentText(chapter.Comments);
        }
        return chapter;
    }


    public Chapter? GetById(int id)
    {
        var chapter = _db.Chapters
          .Include(c => c.Comments!.Where(comment => comment.ParentId == null))
            .ThenInclude(comment => comment.Replys!) 
          .AsNoTracking()
          .SingleOrDefault(c => c.Id == id);

        if(chapter != null) {
            CommentHelpers.ReplaceDeletedCommentText(chapter.Comments);
        }
        return chapter;
    }
          

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