using System.Text.Json.Serialization;

public class Comment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Text { get; set; } = " ";

    //id of comment thats being replied to 
    [JsonIgnore]
    public Comment? Parent { get; set; }
    public int? ParentId { get; set; }

    [JsonIgnore]
    public Book Book { get; set; } = null!;
    public int BookId { get; set; }

    [JsonIgnore]
    public Chapter? Chapter { get; set; }
    public int? ChapterId { get; set; }

    [JsonIgnore]
    public ICollection<Comment> Replys { get; set; } = new List<Comment>();

}