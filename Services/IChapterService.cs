public interface IChapterService 
{
    IEnumerable<Chapter> GetAllForBook(int bookId);
    Chapter Add(Chapter chapter);
    bool Remove(int id);
    Chapter? GetByNumber(int bookId, int num);
    Chapter? GetById(int id);
}