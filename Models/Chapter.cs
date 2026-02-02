using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


public class Chapter
{
    public int Id { get; set; }
    
    [Required]
    public int BookId { get; set; }

    [JsonIgnore]
    public Book? Book { get; set; }

    [Required]
    public int Number { get; set; }

    [Required]
    public string Title { get; set; } = " ";

    public ICollection<Comment>? Comments { get; set; }
}