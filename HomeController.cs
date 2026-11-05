using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        static List<Author> authors = new List<Author>()
        {
            new Author { Id = 1, Name = "J.K. Rowling", Country = "UK" },
            new Author { Id = 2, Name = "Robert", Country = "USA" }
        };

        static List<Book> books = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Title = "Harry Potter",
                Price = 1500,
                AuthorName = "J.K. Rowling"
            }
        };

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            model.Books = books;
            model.Authors = authors;

            return View(model);
        }

        [HttpPost]
        public IActionResult AddBook(string title, decimal price, string authorName)
        {
            Book book = new Book();

            book.Id = books.Count + 1;
            book.Title = title;
            book.Price = price;
            book.AuthorName = authorName;

            books.Add(book);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddAuthor(string name, string country)
        {
            Author author = new Author();

            author.Id = authors.Count + 1;
            author.Name = name;
            author.Country = country;

            authors.Add(author);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveBook(int id)
        {
            Book selectedBook = new Book();
            bool found = false;

            foreach (Book book in books)
            {
                if (book.Id == id)
                {
                    selectedBook = book;
                    found = true;
                    break;
                }
            }

            if (found)
            {
                books.Remove(selectedBook);
            }

            return RedirectToAction("Index");
        }
    }
}