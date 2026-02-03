using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _comments;

    public CommentController(ICommentService comments)
    {
        _comments = comments;
    }

    [HttpGet("{bookId}/{chapterId}")]
    public IActionResult Get(int bookId, int chapterId)
    {
        var comments = _comments.GetAllForChapter(chapterId);
        return comments is null ? NotFound() : Ok(comments);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var comments = _comments.GetReplies(id);
        return comments is null ? NotFound() : Ok(comments);
    }

    [HttpPost]
    public IActionResult Create(Comment comment)
        => Ok(_comments.Add(comment));

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _comments.Remove(id);
    
        if (!result)
            return NotFound();
        return NoContent();
    }
}