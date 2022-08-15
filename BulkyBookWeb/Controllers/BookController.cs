using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
    
        public IActionResult Index()
        {
            IEnumerable<Book> objCategoryList = _db.Books;
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Add(book);
                _db.SaveChanges();
                TempData["success"] = "Book created successfully";
                return RedirectToAction("Index");
            }
            return View(book);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bookFromDb = _db.Books.Find(id);

            if (bookFromDb == null)
            {
                return NotFound();
            }
            return View(bookFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book category)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Book updated successfully";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bookFromDb = _db.Books.Find(id);

            if (bookFromDb == null)
            {
                return NotFound();
            }
            return View(bookFromDb);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBook(int? id)
        {
            var category = _db.Books.Find(id);
            if (category == null) return NotFound();
            _db.Books.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Book deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
