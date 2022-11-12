using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using my_books.Data.Models;
using my_books.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Data.Services
{
    public class BookService
    {
        public AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

       public void AddBook(BookVm book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead : null,
                Rate = book.IsRead ? book.Rate : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now

            };
            _context.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = _context.Books.ToList();
            return books;
        }

        public Book GetBookById(int id)
        {
            Book book = _context.Books.Where(n => n.Id == id).FirstOrDefault();
            return book;
        }

       
    }
}
