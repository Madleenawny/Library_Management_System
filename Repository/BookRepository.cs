using Final.Models;
using Microsoft.EntityFrameworkCore;

namespace Final.Repository
{
    public class BookRepository : IBookRepository
    {
        LibEntity context=new LibEntity();

        public List<Book> GetAll()
        {
            return context.Books.ToList();
        }
        public List<Book> GetAllBooksWithCatgData()
        {
             return context.Books.Include(c => c.Category).ToList();
        }
        public Book GetById(int id)
        {
            return context.Books.FirstOrDefault(x => x.ID == id);
        }
        public void Insert(Book item)
        {
            context.Books.Add(item);
            context.SaveChanges();
        }
        public void Edit(int id, Book item)
        {
            Book oldBok = GetById(id);          
            oldBok.Author = item.Author;
            oldBok.Title = item.Title;
            oldBok.LangOfBook = item.LangOfBook;
            oldBok.CatgID = item.CatgID;
            context.SaveChanges();
            
        }
        public void Delete(int id)
        {
            Book oldBok = GetById(id);
            context.Books.Remove(oldBok);
            context.SaveChanges();
        }
    }
}
