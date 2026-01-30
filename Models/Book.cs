using System.Text.Json.Serialization;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = " ";
    public string Author { get; set; } = " ";
    public string Isbn { get; set; } = " ";


    //TODO: chapters, discussion, ratings
    [JsonIgnore]
    public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
    [JsonIgnore]
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

}