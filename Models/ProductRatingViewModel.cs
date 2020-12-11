using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Models
{
    public class ProductRatingViewModel
    {
        [Key]
        public int ProdId { get; set; }
        [Required]
        public int Rating { get; set; }
      
    }
}
