using Final.Models;

namespace Final.Repository
{
    public interface IReaderRepository
    {
        List<Reader> GetAll();
        Book GetById(int id);
        void Insert(Reader item);
        void Edit(int id, Reader item);
        void Delete(int id);

    }
}
