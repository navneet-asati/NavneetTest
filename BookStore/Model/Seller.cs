﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Model
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        public List<Book> Books { get; set; } // Navigation property
    }
}
