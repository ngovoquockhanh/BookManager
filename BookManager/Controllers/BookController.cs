using BookManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.Entity;



namespace BookManager.Controllers
{
    public class BookController : Controller

    {
        BookManagerContext context = new BookManagerContext();
        // GET: Book
        public ActionResult ListBook()
        {
            var listBook = context.Book.ToList();
            return View(listBook);
        } 
        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Book.SingleOrDefault(p => p.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);

        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBook([Bind(Include = "Id,Author,Title,Description,Image_cover,Price")] Book book)
        {
            if(ModelState.IsValid)
            {
                context.Book.Add(book);
                context.SaveChanges();
                return RedirectToAction("ListBookModel");
            }
            return View(book);
        }
        public ActionResult EditBook()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook([Bind(Include = "Id,Author,Title,Description,Image_cover,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                context.Entry(book).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("ListBookModel");
            }
            return View(book);
        }

        public ActionResult DeleteBook(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = context.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("DeleteBook")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = context.Book.Find(id);
            context.Book.Remove(book);
            context.SaveChanges();
            return RedirectToAction("ListBookModel");
        }
    }
    }
