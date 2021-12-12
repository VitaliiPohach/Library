using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public interface IAuthors
    {
        Task<IList<Author>> GetAllAsync();

        Task<Author> GetByIdAsync(int Id);
        
        Task AddAsync(Author model);

        Task EditAsync(Author model);

        Task DeleteAsync(int id);
    }
}
