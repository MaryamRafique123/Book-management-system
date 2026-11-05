using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class HomeViewModel
    {
        public List<Book> Books { get; set; }

        public List<Author> Authors { get; set; }
    }
}