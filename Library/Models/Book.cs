using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
        public bool IsReserved { get; set; }
    }
}
