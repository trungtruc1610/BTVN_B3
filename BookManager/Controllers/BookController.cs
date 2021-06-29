using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BookManager.Models;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        BookManagerContext DBContext = new BookManagerContext();

        public ActionResult Index()
        {
            var BookList = DBContext.Books.ToList();

            return View("ListBook", BookList);
        }

        public ActionResult ListBook()
        {
            var BookList = DBContext.Books.ToList();

            return View(BookList);
        }

        [Authorize]
        public ActionResult Buy(int ID)
        {
            var BookList = DBContext.Books.SingleOrDefault(Book => Book.ID == ID);

            if (BookList == null)
            {
                return HttpNotFound();
            }

            return View(BookList);
        }

        [Authorize]
        public ActionResult Modify(int ID)
        {
            var EditBook = DBContext.Books.First(Book => Book.ID == ID);
            return View(EditBook);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Modify(int ID, FormCollection Collection)
        {
            var EditBook = DBContext.Books.First(Book => Book.ID == ID);
            if (EditBook != null)
            {
                EditBook.ID = Convert.ToInt32(Collection["ID"]);

                UpdateModel(EditBook);
                DBContext.SaveChanges();
                return RedirectToAction("ListBook");
            }
            return this.Modify(ID);
        }

        [Authorize]
        public ActionResult Remove(int ID)
        {
            var RemoveBook = DBContext.Books.Where(Book => Book.ID == ID).First();

            if (RemoveBook == null) return HttpNotFound();

            return View(RemoveBook);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Remove(int ID, FormCollection collection)
        {
            var RemoveBook = DBContext.Books.Where(Book => Book.ID == ID).First();

            if (RemoveBook != null)
            {
                DBContext.Books.Remove(RemoveBook);
                DBContext.SaveChanges();

                return RedirectToAction("ListBook");
            }

            return RedirectToAction("ListBook");
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Create(Book Book, FormCollection Collection)
        {
            if (ModelState.IsValid)
            {
                DBContext.Books.Add(Book);
                DBContext.SaveChanges();
                return RedirectToAction("ListBook");
            }

            return this.Create();
        }
    }
}