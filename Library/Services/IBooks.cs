using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public interface IBooks
    {
        Task<IList<Book>> GetAllAsync();

        Task<Book> GetByIdAsync(int Id);

        Task AddAsync(Book model);

        Task EditAsync(Book model);

        Task DeleteAsync(int id);
    }
}
