namespace BooksWebpage.Utils;

public static class CommentHelpers
{
    public static void ReplaceDeletedCommentText(ICollection<Comment>? comments)
    {
        if (comments == null) return;

        foreach (var comment in comments)
        {
            if (comment.IsDeleted)
                comment.Text = "[deleted]";
            
            ReplaceDeletedCommentText(comment.Replys);
        }
    }
}