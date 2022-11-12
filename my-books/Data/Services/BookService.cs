using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using my_books.Data.Models;
using my_books.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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

        public List<Book> GetAllBooks() => _context.Books.ToList();
        

        public Book GetBookById(int id) => _context.Books.Where(n => n.Id == id).FirstOrDefault();
            
        
        public Book UpdateBookById(int id, BookVm book)
        {
            var _book = _context.Books.Where(i => i.Id == id).FirstOrDefault();

            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead : null;
                _book.Rate = book.IsRead ? book.Rate : null;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverUrl = book.CoverUrl;
               
                _context.SaveChanges();
            }
            
            return _book;
            
        }

        public void DeleteBookById(int bookId)
        {
            var _book = _context.Books.Where(i => i.Id == bookId).FirstOrDefault();

            if (_book !=null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
       
    }
}
