using Final.Models;
using System.Reflection.PortableExecutable;

namespace Final.Repository
{
    public class ReaderRepository  
    {
        LibEntity context = new LibEntity();
        public List<Reader> GetAll()
        {
            return context.Readers.ToList();
        }
        public Reader GetById(int id)
        {
            return context.Readers.FirstOrDefault(x => x.ID == id);
        }
        public void Insert(Reader item)
        {
            context.Readers.Add(item);
            context.SaveChanges();
        }
        public void Edit(int id, Reader item)
        {
            Reader oldRed = GetById(id);
            oldRed.Name = item.Name;
            oldRed.ISBN = item.ISBN;
            oldRed.Address = item.Address;
            oldRed.Phone = item.Phone;
            oldRed.Email = item.Email;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Reader oldRed = GetById(id);
            context.Readers.Remove(oldRed);
            context.SaveChanges();

        }
    }
}
