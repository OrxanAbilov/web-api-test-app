using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Models.Book()
                    {
                        Title = "1st Book",
                        Description = "1st Book Desc",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-4),
                        Rate = 5,
                        Genre = "Biography",
                        Author = "BookAuthor",
                        CoverUrl = "http://...",
                        DateAdded = DateTime.Now

                    },
                    new Models.Book()
                    {
                        Title = "2nd Book",
                        Description = "2nd Book Desc",
                        IsRead = false,
                        Genre = "Biography",
                        Author = "BookAuthor",
                        CoverUrl = "http://...",
                        DateAdded = DateTime.Now

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
