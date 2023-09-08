using BookStore.Repository;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        private readonly IBookRepository _bookrepository;

        public BookStoreController(IBookRepository bookrepository)
        {
            _bookrepository = bookrepository;
        }
       
        [Authorize]
        [HttpPost("AddSeller")]
        public async Task<IActionResult> AddSeller([FromBody] SellerModel sellerModel)
        {
            var seller = await _bookrepository.AddSellerAsync(sellerModel);
            return Ok(seller);
        }
        [Authorize]
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] BookModel bookmodel, int SellerId)
        {
            try
            {
                var bookId = await _bookrepository.AddBookAsync(bookmodel, SellerId);
                return Ok(bookId);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return StatusCode(500, "An error occurred while adding the mobile phone.");
            }
        }
    }
}
