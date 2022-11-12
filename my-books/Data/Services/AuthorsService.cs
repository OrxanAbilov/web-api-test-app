using my_books.Data.Models;
using my_books.Data.ViewModel;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        public AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }



        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                Name = author.Name
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
    }
}
