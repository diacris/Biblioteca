using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biblioteca.Controllers
{
    public class BooksController : Controller


    {
        private static List<BookModel> listaCarti = new List<BookModel>();
        private static int contorIdCarti = 0;

        // GET: Books
        public ActionResult List()
        {
            List<BookModel> date = new List<BookModel>();
            return View(listaCarti);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BookModel book)
        {
            contorIdCarti++;
            book.Id = contorIdCarti;
            listaCarti.Add(book);
            return View("Success");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var carteCuId = listaCarti.First(x => x.Id == id);
                     
            return View(carteCuId);
        }

        [HttpPost]
        public ActionResult Edit(BookModel book)
        {
            var carteCuId = listaCarti.First(x => x.Id == book.Id);

            //carteCuId = book;

            carteCuId.Name = book.Name;
            carteCuId.ISBN = book.ISBN;
            carteCuId.Year = book.Year;
            carteCuId.AuthorName = book.AuthorName;
             

            return View("List", listaCarti);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var carteCuId = listaCarti.First(x => x.Id == id);
            listaCarti.Remove(carteCuId);
            return View("List", listaCarti);
        }
    }
}