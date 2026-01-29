using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ChapterController : ControllerBase
{
    private readonly IChapterService _chapters;

    public ChapterController(IChapterService chapters)
    {
        _chapters = chapters;
    }

    [HttpGet("{bookId}")]
    public IActionResult Get(int bookId)
    {
        var chapters = _chapters.GetAllForBook(bookId);
        return chapters is null ? NotFound() : Ok(chapters);
    }

    [HttpGet("{bookId}/{chapterNum}")]
    public IActionResult Get(int bookId, int chapterNum)
    {
        var chapter = _chapters.GetByNumber(bookId, chapterNum);
        return chapter is null ? NotFound() : Ok(chapter);
    }

    [HttpPost]
    public IActionResult Create(Chapter chapter)
        => Ok(_chapters.Add(chapter));
}