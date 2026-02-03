using Microsoft.EntityFrameworkCore;
using BooksWebpage.Data;

public class CommentService : ICommentService
{
    private readonly ApplicationDbContext _db;

    public CommentService(ApplicationDbContext db)
    {
        _db = db;
    }

     public IEnumerable<Comment> GetAllForChapter(int chapterId)
        => _db.Comments
          .Where(c => c.ChapterId == chapterId)
          .AsNoTracking()
          .ToList();

    public IEnumerable<Comment> GetReplies(int id)
        => _db.Comments
          .Where(c => c.ParentId == id)
          .AsNoTracking()
          .ToList();

    public Comment Add(Comment comment)
    {
        _db.Comments.Add(comment);
        _db.SaveChanges();
        return comment;
    }

    public bool Remove(int id)
    {
        var comment = _db.Comments.Find(id);
        if (comment == null)
            return false;

        comment.IsDeleted = true;
        _db.SaveChanges();
        return true;
    }
}
