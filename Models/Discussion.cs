public class Discussion
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    public int? ChapterId { get; set; }
    public Chapter? Chapter { get; set; }

    public int CreatedByUserId { get; set; }
    public User CreatedBy { get; set; } = null!;

}