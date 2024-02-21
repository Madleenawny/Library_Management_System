using Final.Models;
using Final.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using System.Diagnostics;

namespace Final.Controllers
{
    public class BookController : Controller
    {

       // LibEntity context = new LibEntity();
        BookRepository bookRepository;
        CategoryRepository categoryRepository;
        public BookController()
        {
            bookRepository = new BookRepository();
            categoryRepository = new CategoryRepository();
        }
        //Book/Index
        public IActionResult Index()
        {
            return View(bookRepository.GetAllBooksWithCatgData());
        }

        //Book/details/id
        public IActionResult Details(int id)
        {
            Book Bok =  bookRepository.GetById(id); //context.Books.Include(c=>c.Category).FirstOrDefault(d => d.ID == id);
            return View("Details", Bok);
        }

        //Book/new
        public IActionResult New()
        {
            ViewData["CatgList"] = categoryRepository.GetAll();
            return View(new Book());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Book Bok)
        {
            if (Bok.Title != null)
            {
                bookRepository.Insert(Bok);
                return RedirectToAction("Index");
            }    
            
            ViewData["CatgList"] = categoryRepository.GetAll(); //context.Categories.ToList();
            return View("New",Bok);
        }


        public IActionResult Edit(int id)
        {
            Book Bok = bookRepository.GetById(id); //context.Books.Include(c => c.Category).FirstOrDefault(d => d.ID == id);
            ViewData["CatgList"] = categoryRepository.GetAll();//context.Categories.ToList();
            return View(Bok);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(int id, Book newBok)
        {
            if (newBok.Author != null)
            {
                bookRepository.Edit(id, newBok);
                return RedirectToAction("Index");
            }
            //ViewData["CatgList"] = categoryRepository.GetAll();//context.Categories.ToList();
            return View("Edit", newBok);

        }

        public IActionResult Delete(int id)
        {
            Book Bok = bookRepository.GetById(id);
            return View(Bok);
        }

        public IActionResult ConfrimDelete(int id)
        {
            bookRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }


}
