using Final.Models;

namespace Final.Repository
{
    public interface IBookRepository 
    {
        List<Book> GetAll();
        List<Book> GetAllBooksWithCatgData();
        Book GetById(int id);
        void Insert(Book item);
        void Edit(int id, Book item);
        void Delete(int id);

    }
}
