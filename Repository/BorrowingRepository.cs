using Final.Models;
using Microsoft.EntityFrameworkCore;

namespace Final.Repository
{
    public class BorrowingRepository : IBorrowingRepository
    {
        LibEntity context = new LibEntity();      
        public List<Borrow> GetAll()
        {
            return context.Borrows.ToList();
        }
        public List<Borrow> GetBorrowingWithAllData()
        {
            return context.Borrows.Include(b => b.Books).Include(d => d.Readers).ToList();
        }
        public Borrow GetById(int id)
        {
            return context.Borrows.FirstOrDefault(x=> x.ID == id);
        }
        public void Insert(Borrow item)
        {
            context.Borrows.Add(item);
            context.SaveChanges();
        }
        public void Edit(int id, Borrow item)
        {
            Borrow oldBrw=GetById(id);
            oldBrw.BookID = item.BookID;
            oldBrw.ReaderID = item.ReaderID;
            oldBrw.BrwDate = item.BrwDate;
            oldBrw.ReturnedDate = item.ReturnedDate;
            oldBrw.BrwDuration = item.BrwDuration;
            oldBrw.ReturnedIn = item.ReturnedIn;
            oldBrw.NumOfDaysLate = item.NumOfDaysLate;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Borrow oldBrw = GetById(id);
            context.Borrows.Remove(oldBrw);
            context.SaveChanges();
        }
    }
}
