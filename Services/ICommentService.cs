public interface ICommentService
{
    IEnumerable<Comment> GetAllForChapter(int chapterId);
    
    IEnumerable<Comment> GetReplies(int id);
    Comment Add(Comment comment);
    bool Remove(int id);

}