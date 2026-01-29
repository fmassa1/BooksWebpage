public class Chapter
{
    public int Id { get; set; }
    
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    public int Number { get; set; }
    public string Title { get; set; } = " ";

    //public ICollection<Discussion> Discussions { get; set; } = new List<Discussion>();
}