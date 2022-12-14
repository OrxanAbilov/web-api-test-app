using my_books.Data.Models;
using my_books.Data.ViewModel;

namespace my_books.Data.Services
{
    public class PublishersService
    {
        public AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context=context;
        }


        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
    }
}
