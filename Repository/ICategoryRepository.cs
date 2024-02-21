using Final.Models;

namespace Final.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        List<Category> GetAllCategDataWithBooks();
        Book GetById(int id);
        void Insert(Book item);
        void Edit(int id, Book item);
        void Delete(int id);

    }
}
