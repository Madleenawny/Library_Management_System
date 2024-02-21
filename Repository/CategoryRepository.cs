using Final.Models;
using Microsoft.EntityFrameworkCore;

namespace Final.Repository
{
    public class CategoryRepository
    {

        LibEntity context = new LibEntity();
        public List<Category> GetAll() 
        {
            return context.Categories.ToList();
        }
        public List<Category> GetAllCategDataWithBooks()
        {
            return context.Categories.Include(s => s.Books).ToList();
        }
        public Category GetById(int id)
        {
            return context.Categories.FirstOrDefault(x => x.ID == id);
        }
        public void Insert(Category item)
        {
            context.Categories.Add(item);
            context.SaveChanges();
        }
        public void Edit(int id ,Category item) 
        {
            Category oldCateg = GetById(id);
            oldCateg.CatgName = item.CatgName;
            context.SaveChanges();
        }
        public void Delete(int id) 
        {
            Category oldCateg = GetById(id);
            context.Categories.Remove(oldCateg);
            context.SaveChanges();
        }

    }

}

