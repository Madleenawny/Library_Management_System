using Final.Models;
using Final.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace Final.Controllers
{

    public class BorrowingController : Controller
    {
        //  LibEntity context = new LibEntity();
        BorrowingRepository borrowingRepository;
        BookRepository bookRepository;
        ReaderRepository readerRepository;

        public BorrowingController()
        {
            borrowingRepository = new BorrowingRepository();
            bookRepository = new BookRepository();
            readerRepository = new ReaderRepository();
        }

        //Borrowing/Index
        public IActionResult Index()
        {
            return View(borrowingRepository.GetBorrowingWithAllData());
        }

        //Borrowing/details/id
        public IActionResult Details(int id)
        {
            Borrow Brw = borrowingRepository.GetById(id);//context.Borrows.FirstOrDefault(d => d.ID == id);
            return View("Details", Brw);
        }

        //Borrowing/new
        public IActionResult New()
        {
            ViewData["BokList"] = bookRepository.GetAll();
            ViewData["RedList"] = readerRepository.GetAll();
            return View(new Borrow());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Borrow Brw)
        {
            if (Brw.BrwDate != null)
            {
                borrowingRepository.Insert(Brw);
                return RedirectToAction("Index");
            }

            ViewData["BokList"] = bookRepository.GetAll();
            ViewData["RedList"] = readerRepository.GetAll();     //context.Categories.ToList();
            return View("New", Brw);
        }


        public IActionResult Edit(int id)
        {
            Borrow Brw = borrowingRepository.GetById(id); //context.Borrows.FirstOrDefault(d => d.ID == id);
            ViewData["BokList"] = bookRepository.GetAll();
            ViewData["RedList"] = readerRepository.GetAll();//context.Categories.ToList();
            return View(Brw);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(int id, Borrow newBorrowing)
        {
            if (newBorrowing.BrwDate != null)
            {
                borrowingRepository.Edit(id, newBorrowing);
                return RedirectToAction("Index");
            }
            //ViewData["BokList"] = bookRepository.GetAll();
            //ViewData["RedList"] = readerRepository.GetAll();
            return View("Edit", newBorrowing);
        }

        public IActionResult Delete(int id)
        {
            Borrow Brw = borrowingRepository.GetById(id);
            return View(Brw);
        }

        public IActionResult ConfrimDelete(int id)
        {
            borrowingRepository.Delete(id);
            return RedirectToAction("Index");
        }
        //------------------------------------------------------//

        //borrowing/BorrowedBook
        public IActionResult BorrowedBook()
        {
            //---------------- Ability to list currently borrowed books -------------------//
            ViewData["BrwBokList"] = borrowingRepository.GetBorrowingWithAllData().     //context.Borrows.Include(d => d.Readers).Include(s => s.Books).
                                    Where(x => x.BrwDuration != null && x.ReturnedDate > DateTime.Now).ToList();

            return View();
        }

        //Borrowing/BooksDueToBeReturned
        // الكتب الواجب استحقاقها
        public IActionResult BooksDueToBeReturned()
        {
            //---------------- Ability to list currently borrowed books that are on due -------------------//
            ViewData["BrwBokList"] = borrowingRepository.GetBorrowingWithAllData().    // context.Borrows.Include(d => d.Readers).Include(s => s.Books).
                                    Where(x => x.BrwDuration != null && x.ReturnedDate < DateTime.Now).ToList();
            return View();
        }


    }
}
