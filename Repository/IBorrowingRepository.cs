using Final.Models;

namespace Final.Repository
{
    public interface IBorrowingRepository 
    {
        List<Borrow> GetAll();
        List<Borrow> GetBorrowingWithAllData();
        Borrow GetById(int id);
        void Insert(Borrow item);
        void Edit(int id, Borrow item);
        void Delete(int id);
    }
}
