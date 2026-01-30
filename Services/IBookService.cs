public interface IBookService
{
    IEnumerable<Book> GetAll();
    Book Add(Book book);
    Book? GetById(int id, bool includeChapters = false);
}