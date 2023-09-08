using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Model
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Author { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int SellerId { get; set; }

        [ForeignKey("SellerId")]
        public Seller Seller { get; set; }

        public bool OfferAccepted { get; set; } // Indicates if the offer has been accepted
        
    }
}
