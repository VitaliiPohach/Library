using Library.DataAccess;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class BookService:IBooks
    {
        private readonly LibraryContext _dbContext;
        private readonly IAuthors _authors;

        public BookService(LibraryContext dbContext, IAuthors authors)
        {
            _dbContext = dbContext;
            _authors = authors;
        }

        public async Task AddAsync(Book model)
        {
            Book books = new Book()
            {
                Title = model.Title,
                IsReserved = model.IsReserved,
                Authors = model.Authors
            };

            await _dbContext.Books.AddAsync(books);

            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task EditAsync(Book model)
        {
            if (!(_dbContext.Books.Any(b => b.Id == model.Id)))
            {
                throw new Exception("On this Id nothing found");
            }
            _dbContext.Books.FirstOrDefault(b => b.Id == model.Id).Authors = model.Authors;
            _dbContext.Books.FirstOrDefault(b => b.Id == model.Id).Title = model.Title;
            _dbContext.Books.FirstOrDefault(b => b.Id == model.Id).IsReserved = model.IsReserved;
            _dbContext.Books.FirstOrDefault(b => b.Id == model.Id).IsArhived = model.IsArhived;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<Book>> GetAllAsync()
        {
            return await _dbContext.Books.Include(b => b.Authors).Where(b=>b.IsArhived==false).ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int Id)
        {
            var book = await _dbContext.Books.Include(b => b.Authors).FirstOrDefaultAsync(a => a.Id == Id);

            return book;
        }


        public  void SaveToFile(string filePath)
        {
            IList<Book> books = new List<Book>();
            List<string> lines = new List<string>();

            books = _dbContext.Books.ToList();

            foreach(Book b in books)
            {
                lines.Add($"{b.Id},{b.Title},{ConvertAuthorsToString(b.Authors)}");

            }

            File.WriteAllLines(filePath, lines);
        }

        public static string ConvertAuthorsToString(List<Author> authors)
        {
            string result = "";
            if(authors.Count == 0)
            {
                return "";
            }

            foreach(Author a in authors)
            {
                result += $" {a.Name} {a.Surname}";
            }

            return result;
        }
    }
}
