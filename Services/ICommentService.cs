public interface ICommentService
{
    IEnumerable<Comment> GetBookComments(int bookId);
    IEnumerable<Comment> GetAllForChapter(int chapterId);
    Comment Add(Comment comment);
    //bool Remove(int id);

}