using BookStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public interface IBookRepository
    {
        Task<int> AddSellerAsync(SellerModel sellermodel);
        Task<int> AddBookAsync(BookModel bookmodel, int SellerId);
    }
}
