using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class AuthorService : IAuthors
    {
        public Task AddAsync(Author model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Author model)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Author>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

       
    }
}
