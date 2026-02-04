public interface ICommentService
{
    IEnumerable<Comment> GetCommentsForChapter(int chapterId);
    
    IEnumerable<Comment> GetReplies(int id);
    Comment SetSpoiler(int id);
    Comment Add(Comment comment);
    bool Remove(int id);

}