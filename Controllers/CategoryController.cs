using Final.Models;
using Final.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace Final.Controllers
{
    public class CategoryController : Controller
    {
        // LibEntity context = new LibEntity();

        CategoryRepository categoryRepository;
        public CategoryController()
        {
            categoryRepository = new CategoryRepository();
        }

        //Categories/Index
        public IActionResult Index()
        {
            return View(categoryRepository.GetAll());
        }

        //Categories/details/id
        public IActionResult Details(int id)
        {
            Category Cat = categoryRepository.GetById(id); //context.Categories.FirstOrDefault(d => d.ID == id);
            return View("Details", Cat);
        }

        //categories/new
        public IActionResult New()
        {
            return View(new Category());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveNew(Category Cat)
        {
                if (Cat.CatgName != null) //custom Valution Catg_id!=0
                {
                    categoryRepository.Insert(Cat);
                   return RedirectToAction("Index");
                }
                   
           
            return View("New",Cat);
        }

        public IActionResult Edit(int id)
        {
            Category Cat = categoryRepository.GetById(id);  //context.Categories.FirstOrDefault(c => c.ID == id);
            return View(Cat);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(int id, Category newCatg)
        {
            if (newCatg.CatgName != null)
            {
                categoryRepository.Edit(id, newCatg);
                return RedirectToAction("Index");
            }

            return View( newCatg);
        }

        public IActionResult Delete(int id)
        {
            Category Catg = categoryRepository.GetById(id); //context.Categories.FirstOrDefault(b => b.ID == id);
            return View(Catg);
        }

        public IActionResult ConfrimDelete(int id)
        {
            categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }

        //--------------------------------------------------------
        public IActionResult AllBooksInCateg()
        {
            ViewData["CatgList"] = categoryRepository.GetAllCategDataWithBooks();
            return View();
        }


       

    }
}
