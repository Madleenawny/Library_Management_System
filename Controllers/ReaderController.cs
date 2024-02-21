using Final.Models;
using Final.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final.Controllers
{
    public class ReaderController : Controller
    {
        //LibEntity context = new LibEntity();

        ReaderRepository readerRepository;
        public ReaderController()
        {
           readerRepository = new ReaderRepository();
        }
        //Reader/Index
        public IActionResult Index()
        {
            return View(readerRepository.GetAll());
        }

        //Reader/details/id
        public IActionResult Details(int id)
        {
            Reader Red = readerRepository.GetById(id); //context.Readers.FirstOrDefault(d => d.ID == id);
            return View("Details", Red);
        }

        //Reader/new
        public IActionResult New()
        {
            return View(new Reader());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Reader Red)
        { 
            if (Red.Name != null) 
            {                    
                readerRepository.Insert(Red);
                return RedirectToAction("Index");  
            }
               
            return View("New",Red);
        }

        public IActionResult Edit(int id)
        {
            Reader Red = readerRepository.GetById(id); //context.Readers.FirstOrDefault(d => d.ID == id);
            return View(Red);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(int id, Reader newReader)
        {
            if (ModelState.IsValid == true)
            {
                readerRepository.Edit(id, newReader);
                return RedirectToAction("Index");
            }
            return View("Edit", newReader);
        }

        public IActionResult Delete(int id)
        {
            Reader Red= readerRepository.GetById(id); //context.Readers.FirstOrDefault(b => b.ID == id);
            return View(Red);
        }
        public IActionResult ConfrimDelete(int id)
        {
            readerRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
