using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class TestData
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            Book[] books = new Book[]
            {
                new Book { Title = "Тигролови", IsReserved = false },
                new Book { Title = "Кайдашева сім'я", IsReserved = false },
                new Book { Title = "Тіні забутих предків" },
                new Book { Title = "Intermezzo" },
                new Book { Title = "Мальована історія незалежної України " },
            };

            Author[] authors = new Author[]
            {     
                new Author { Name = "Нечуй", Surname = "Левицький" },
                new Author { Name = "Іван", Surname = "Багряний" },
                new Author { Name = "Михайло", Surname = " Коцюбинський" },
                new Author { Name = "Дмитро", Surname = "Капранов" },
                new Author { Name = "Віталій", Surname = "Капранов" }
            };

            books[0].Authors.Add(authors[1]);
            books[1].Authors.Add(authors[0]);
            books[2].Authors.Add(authors[2]);
            books[3].Authors.Add(authors[2]);
            books[4].Authors.AddRange(new List<Author> { authors[3], authors[4] });

            foreach(Book book in books)
                context.Books.Add(book);
            context.SaveChanges();

            foreach (Author author in authors)
                context.Authors.Add(author);
            context.SaveChanges();
        }
    }
}
