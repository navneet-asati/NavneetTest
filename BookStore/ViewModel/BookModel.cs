using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModel
{
    public class BookModel
    {
       
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public int SellerId { get; set; }

    }
}
