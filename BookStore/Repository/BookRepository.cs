using BookStore.Model;
using BookStore.ViewModel;
using MobApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository : IBookRepository
    {

        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //add book
        public async Task<int> AddBookAsync(BookModel bookmodel, int SellerId)
        {
            var seller = await _context.Sellers.FindAsync(SellerId);

            if (seller == null)
            {
                throw new ArgumentException("Invalid Seller ID");
            }

            var Book = new Book()
            {
                Title = bookmodel.Title,
                Author = bookmodel.Author,
                Price = bookmodel.Price,
                SellerId = SellerId
               
            };

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return Book.BookId;
        }

        //add seller
        public async Task<int> AddSellerAsync(SellerModel sellermodel)
        {
            var seller = new Seller()
            {
                Name = sellermodel.Name,
                Location = sellermodel.Location
                
            };

            _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();

            return seller.SellerId;
        }
    }
}
