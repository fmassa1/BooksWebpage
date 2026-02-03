using System.Text.Json.Serialization;

public class Comment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Text { get; set; } = " ";
    public int? BookId { get; set; }
    public int? ChapterId { get; set; }
    public int? ParentId { get; set; }

    public bool IsDeleted { get; set; } = false;

    [JsonIgnore]
    public Comment? Parent { get; set; }

    [JsonIgnore]
    public Book? Book { get; set; }

    [JsonIgnore]
    public Chapter? Chapter { get; set; }

    public ICollection<Comment>? Replys { get; set; }


}