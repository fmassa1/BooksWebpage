public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = " ";
    public string Author { get; set; } = " ";
    public string Isbn { get; set; } = " ";


    //TODO: chapters, discussion, ratings
    public ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

}